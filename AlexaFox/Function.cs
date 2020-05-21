using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Amazon.Lambda.Core;
using Alexa.NET;
using Newtonsoft.Json;
using Alexa.NET.Response;
using Alexa.NET.Request.Type;
using Alexa.NET.Request;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
//[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.))]
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]
//[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace AlexaFox
{
    public class Function
    {
        
        /// <summary>
        /// A simple function that takes a string and does a ToUpper
        /// </summary>
        /// <param name="input"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public SkillResponse FunctionHandler(SkillRequest input, ILambdaContext context)
        {
            var logger = context.Logger;

            switch (input.Request)
            {
                case LaunchRequest launchRequest: return HandleLaunch(launchRequest, logger);
                    //case IntentRequest intentRequest: return HandleIntent(intentRequest, logger);
            }

            throw new NotImplementedException("The quick brown fox was smart! Not!");

            //return "The quick brown fox was smart!";
            //return input?.ToUpper();
        }

        private SkillResponse HandleLaunch(LaunchRequest launchRequest, ILambdaLogger logger)
        {
            logger.LogLine($"LaunchRequest made");

            var response = ResponseBuilder.Tell(new PlainTextOutputSpeech()
            {
                Text = "Alexa, please tell me you're working!"
            });

            return response;
        }
    }
}
