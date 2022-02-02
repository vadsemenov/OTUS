using System.Text.Json;
using System.Text.Json.Serialization;


namespace Serialization
{

    class TestClass
    {
        [JsonInclude]
        public int _firstInt;

        [JsonInclude]
        public string _firstString;

        public double FirstProperty { get; set; }
        public string SecondProperty { get; set; }

        public TestClass()
        {
            _firstInt = 56;
            _firstString = "Строка1";
            FirstProperty = 89.7;
            SecondProperty = "Строка2";
        }
    }
}
