using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using SGEnviro.Forecasts;
using System.Net.Http;
using System.Xml.Linq;

namespace SGEnviro
{
    public class SGEnviroApi
    {
        /// <summary>
        /// The URL for the NEA PSI API.
        /// {0} - The API key.
        /// </summary>
        private const string ApiUrl = "http://www.nea.gov.sg/api/WebAPI/?dataset=psi_update&keyref={0}";

        private readonly string apiKey;

        public SGEnviroApi(string apiKey)
        {
            this.apiKey = apiKey;
        }

        private void ThrowExceptionIfNoApiKey()
        {
            if (String.IsNullOrWhiteSpace(apiKey))
            {
                throw new InvalidOperationException("No API key was given.");
            }
        }

        private HttpClientHandler GetCompressionHandler()
        {
            var handler = new HttpClientHandler();
            if (handler.SupportsAutomaticDecompression)
            {
                handler.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
            }

            return handler;
        }

        private void ThrowExceptionIfResponseError(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException("Couldn't retrieve data: got HTTP " + response.StatusCode);
            }
        }

        /// <summary>
        /// Asynchronously retrieves PSI data.
        /// </summary>
        /// <returns>A <see cref="PsiUpdate" /> with the latest available PSI information.</returns>
        public async Task<PsiUpdate> GetPsiUpdateAsync()
        {
            ThrowExceptionIfNoApiKey();

            var requestUrl = string.Format(ApiUrl, apiKey);

            var compressionHandler = GetCompressionHandler();
            using (var client = new HttpClient(compressionHandler))
            {
                var response = await client.GetAsync(requestUrl);

                ThrowExceptionIfResponseError(response);

                var parsedXml = XElement.Parse(await response.Content.ReadAsStringAsync());
                return PsiUpdate.FromXElement(parsedXml);
            }
        }
    }
}
