using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpInterpreterClasses.Instructions.abstractions
{
    using Microsoft.VisualBasic;

    /// <summary>
    /// A user can use their own text file to write new methods,
    /// which can be input into the class system and deserialized
    /// with arguments coming from the application. Which would be 
    /// considered a method interface. Therefore this class should 
    /// not be static.
    /// </summary>
    public abstract class MethodCreator
    {
        private Dictionary<uint, Action> methods;

        public Dictionary<uint, Action> Methods { get => this.methods; }

        public MethodCreator()
        {
            this.methods = new Dictionary<uint, Action>();
        }

        public void AbstractMethod(Action method, uint value)
        {
            if (this.Methods.ContainsKey(value))
            {
                string response = Interaction.InputBox($"Index {value} has already been used for {this.Methods[value].ToString()}. Replace it? (Y/N)").ToLower();
                byte overwrite;

            INVALID_INPUT_RESTART_LOOP:
                switch (response)
                {
                    case "y":
                        overwrite = 0;
                        break;
                    case "n":
                        overwrite = 1;
                        break;
                    default:
                        response = Interaction.InputBox($"Please enter either a Y, or an N. Replace it? (Y/N)").ToLower();
                        goto INVALID_INPUT_RESTART_LOOP;
                }

                switch (overwrite)
                {
                    case 0:
                        this.methods.Remove(value);
                        this.methods.Add(value, method);
                        break;
                    case 1:
                        break;
                    default:
                        goto EXIT_NO_INTERRUPTION;
                }
                return;
            }
        EXIT_NO_INTERRUPTION:
            this.methods.Add(value, method);
        }

        public void MethodJump(uint sum)
        {
            foreach (KeyValuePair<uint, Action> kvp in this.Methods)
            {
                if (sum == kvp.Key)
                {
                    // Calls the associated method (Action).
                    kvp.Value();
                }
            }
        }

        /* GLOBAL OPERATORS */

        // This will always be updated by the method. An interface must be implemented to ensure this.
        // Place the creator on the stack;
        // it shouldn't be set outside of the scope of this class file.
        private static string return_ = "uninitialized";
        public string Return { get => return_; }

        /// <summary>
        /// Example: this method definition could just be a readout from an XML file.
        /// IE class loads XML class serializtion of predefined methods.
        /// </summary>
        public void ColorBlue()
        {
            return_ = "API call resulted in: 'Blue'";
        }
    }
}
