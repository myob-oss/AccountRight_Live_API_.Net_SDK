using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
