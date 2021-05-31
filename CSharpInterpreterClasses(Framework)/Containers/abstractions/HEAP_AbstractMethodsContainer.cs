namespace CSharpInterpreterClasses.Containers.abstractions
{
    using System.Collections.Generic;

    public abstract class HEAP_AbstractMethodsContainer
    {
        /* private */
        private List<List<string>> volatileEventContainer;
        private Dictionary<int, List<string>> eventHistory;
        private List<List<byte>> volatileDecimalCommands;
        private Dictionary<int, List<byte>> decimalHistory;

        /* Public */
        public List<List<string>> VolatileEventContainer { get => this.volatileEventContainer; set => this.volatileEventContainer = value; }
        public Dictionary<int, List<string>> EventHistory { get => this.eventHistory; set => eventHistory = value; }
        public List<List<byte>> VolatileDecimalCommands { get => this.volatileDecimalCommands; set => volatileDecimalCommands = value; }
        public Dictionary<int, List<byte>> DecimalHistory { get => this.decimalHistory; set => decimalHistory = value; }

        // Needs to implement a hashtable / sorting class.
        // Can store char counts at beginning or end of array same as vertex, indices, shader array byte mapping in OpenGL.

        public HEAP_AbstractMethodsContainer()
        {
            this.volatileEventContainer = new List<List<string>>();
            this.eventHistory = new Dictionary<int, List<string>>();
            this.volatileDecimalCommands = new List<List<byte>>();
            this.decimalHistory = new Dictionary<int, List<byte>>();
        }

        public string AllocateStrings(List<string> strings, int index)
        {
            this.volatileEventContainer.Add(strings);

            foreach (string string_ in strings)
            {
                this.volatileDecimalCommands.Add(this.ToDecimalList(string_));
            }
            string eventMessage = "The request did not require any changes to memory.";
            return eventMessage;
        }

        public List<byte> ToDecimalList(string string_)
        {
            List<byte> newDecimalList = new List<byte>();
            int stringLength = string_.Length;

            for (int i = 0; i < stringLength; i++)
            {
                newDecimalList.Add((byte)string_[i]);
            }

            return newDecimalList;
        }
    }
}