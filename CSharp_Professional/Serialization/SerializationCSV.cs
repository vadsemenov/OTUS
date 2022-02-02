using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading;

namespace Serialization
{
    public static class SerializationCSV
    {
        private const char EQUAL = '=';
        private const char SEMICOLON = ';';

        /// <summary> Serialize from object to CSV </summary>
        /// <param name="obj">any object</param>
        /// <returns>CSV</returns>
        public static string SerializeFromObjectToCSV(object obj)
        {

            Type testClassType = obj.GetType();


            FieldInfo[] fieldsInfos = testClassType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static);
            PropertyInfo[] propertiesInfos = testClassType.GetProperties(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static);


            StringBuilder fileText = new StringBuilder();


            //Writing fields to CSV
            foreach (FieldInfo fieldInfo in fieldsInfos)
            {
                fileText.Append(fieldInfo.Name + EQUAL + fieldInfo.GetValue(obj) + SEMICOLON);
            }
            fileText.AppendLine();


            //Writing properties to CSV
            foreach (PropertyInfo propertyInfo in propertiesInfos)
            {
                fileText.Append(propertyInfo.Name + EQUAL + propertyInfo.GetValue(obj) + SEMICOLON);
            }
            fileText.AppendLine();

            return fileText.ToString();
        }



        /// <summary> Deserialize from CSV to object</summary>
        /// <param name="csv">string in CSV format</param>
        /// <returns>object</returns>
        public static object DeserializeFromCSVToObject(string csv)
        {
            //First string - fields, second - properties
            string[] _csvText = csv.Split("\r\n");

            Dictionary<object,object> _fieldsDictionary=null, _propertiesDictionary=null;

            if (_csvText.Length > 0)
            {
                 _fieldsDictionary = GetPairValuesOfFieldsAndPropertiesFromCSV(_csvText[0]);
            } 
            
            if (_csvText.Length >= 2)
            {
                 _propertiesDictionary = GetPairValuesOfFieldsAndPropertiesFromCSV(_csvText[1]);
            }

            TestClass testClass = new TestClass();
            Type testClassType = testClass.GetType();

            FieldInfo[] fieldsInfos = testClassType.GetFields();
            PropertyInfo[] propertiesInfos = testClassType.GetProperties();

            object _value;
            foreach (FieldInfo fieldInfo in fieldsInfos)
            {
                Type fieldType = fieldInfo.FieldType;

                _fieldsDictionary.TryGetValue(fieldInfo.Name, out _value);


                fieldInfo.SetValue(testClass, Convert.ChangeType(_value, fieldType));

            }


            foreach (PropertyInfo propertyInfo in propertiesInfos)
            {
                Type propertyType = propertyInfo.PropertyType;

                _propertiesDictionary.TryGetValue(propertyInfo.Name, out _value);

                propertyInfo.SetValue(testClass, Convert.ChangeType(_value, propertyType));
            }

            return testClass;
        }


        /// <summary>
        /// Split string to pair Variable-Value
        /// </summary>
        /// <param name="csv">String to split</param>
        /// <returns>Pair Variable-Value</returns>
        private static Dictionary<object, object> GetPairValuesOfFieldsAndPropertiesFromCSV(string csv)
        {
            string[] _fieldsPair = csv.Split(SEMICOLON);
            var _pairDictionary = new Dictionary<object, object>();

            string[] _var_value = null;
            foreach (string pair in _fieldsPair)
            {
                if (pair.Contains(EQUAL))
                {
                    _var_value = pair.Split(EQUAL);
                    _pairDictionary.Add(_var_value[0], _var_value[1]);
                }
            }
            return _pairDictionary;
        }

    }
}
