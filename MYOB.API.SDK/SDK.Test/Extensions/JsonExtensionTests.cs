using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger;
using NUnit.Framework;
using MYOB.AccountRight.SDK.Extensions;
using Newtonsoft.Json;

namespace SDK.Test.Extensions
{
    [TestFixture]
    public class JsonExtensionTests
    {
        public enum MyEnum
        {
            AnEntry
        }

        public class MyClass
        {
            public MyEnum Data { get; set; }
        }

        [Test]
        public void Serializer_Serializes_Enums_As_String()
        {
            // Act
            var serialized = new MyClass().ToJson();
            dynamic t = JsonConvert.DeserializeObject(serialized);

            // Assert
            Assert.AreEqual(Newtonsoft.Json.Linq.JTokenType.String, t.Data.Type);
        }

        [Test]
        public void Deserializer_Deserializes_Object()
        {
            // Act
            var category = new Category()
                {
                    Description = "test",
                    DisplayID = "1234"
                };
            var serialized = JsonConvert.SerializeObject(category);

            var t = serialized.FromJson<Category>();

            // Assert
            Assert.AreEqual(category.Description, t.Description);
            Assert.AreEqual(category.DisplayID, t.DisplayID);
        }
    }
}
