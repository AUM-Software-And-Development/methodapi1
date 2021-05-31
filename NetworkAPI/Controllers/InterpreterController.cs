using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SiteHost.Controllers
{
    using CSharpInterpreterClasses.Containers.implementations;
    using CSharpInterpreterClasses.Analyzers;
    using CSharpInterpreterClasses.Instructions.implementations;

    public class InterpreterController : ApiController
    {
        private static HEAP_EventStorage eventStorage = new HEAP_EventStorage();
        private static int index = 0;

        public string Get()
        {
            return "API key was not entered.";
        }

        [HttpPost]
        public string Post([FromBody] string inputString)
        {
            bool testing = true;
            List<string> inputs = new List<string>()
            {
                inputString,
            };

            try
            {
                string return_release;
                return_release = eventStorage.AllocateStrings(inputs, index);
                List<List<byte>> hostHistory = new List<List<byte>>();
                if (testing)
                {
                    List<string> add = new List<string>
                    {
                        "00000/TEST/",
                        /* API Key for testing is "TESTINGIO" */
                        // TESTINGIO Sum =84+69+83+84+73+78+71+73+79= 694
                    };
                    eventStorage.AllocateStrings(add, index);
                    Lexer.RemoveNonEnglishValues(eventStorage.VolatileDecimalCommands, ref hostHistory);

                    uint sum = 0;
                    for (int i = 0; i < hostHistory[index].Count; i++)
                    {
                        sum += (uint)hostHistory[index][i];
                    }
                    index += 2; // Only here for testing purposes (LIFO ordering).

                    PublicMethodSetter availableMethods = new PublicMethodSetter();
                    availableMethods.AbstractMethod(availableMethods.ColorBlue, 694); /* "TESTINGIO" */
                    availableMethods.MethodJump(sum);
                    return $"{availableMethods.Return}";
                }
            }
            catch (Exception ex)
            {
                return $"{ex.Message}";
            }

            return $"API key was entered, but {inputString} isn't valid.";
        }
    }
}
