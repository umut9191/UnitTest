using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTest.Test
{
    public class CalculatorTest
    {
        //Test Classlarda Constructor;
        public Calculator calculator { get; set; }

        public CalculatorTest()
        {
            calculator =  new Calculator();
        }


        //
        //Test Methodu isimlendirme kuralı;
        //[MethodName_StateUnderTest_ExpectedBehavior]
        //Test methodu isimlendirme önemlidir çünkü ismine
        //bakarak yapıyor olduğu işi direk bize anlatabilmeli.
        //Örnek;
        //test_add_simpleValues_returnTotalValue


        //
        //
        //Test methodları herhangi bir parametre almıyorlar ise Fact attributesi kullanılıyor.
        [Fact]//bu aynı zamanda bu methodun bir test methodu olduğunu belirtiyor.
        public void test_add()
        {
            // //Arrange
            // int a = 5;
            // int b = 20;
            // var caclculator =new Calculator();
            // //Act
            //var total = caclculator.add(a, b);
            // //Assert
            // Assert.Equal<int>(25, total);

            //***///Contain/DoesNotContain;
            //var names = new List<string>() {"umut","sürmeli","aaaa"};
            ////Assert.Contains("umut", "umut sürmeli");
            ////Assert.DoesNotContain("aaa", "umut sürmeli");
            //Assert.Contains(names, x => x == "umut");


            //***///True/False;
            //Assert.True(5 > 2);
            //Assert.False(5 < 2);


            //***///Match/DoesNotMatch
            //Regex kodları ile çalışıyorlar
            //var regEx = "^dog";
            //Assert.Matches(regEx, "dog xyzt");
            //Assert.DoesNotMatch(regEx, "xyzt dog");


            //***///StartsWith/EndsWith
            //Assert.StartsWith("bir", "bir masal");
            //Assert.EndsWith("bir", "masal bir");

            //***///Empty/NotEmpty
            //dizinin boş olup olmadığını kontrol eder.
            //Empty:eğer dizinin içi boş ise true döner.
            //NotEmpty:eğer dizinin içi boş değil ise true döner.
            //int[] array = new int[3];
            //List<int> list = new List<int>();
            //array[0] = 1;
            //Assert.Empty(list);
            //Assert.NotEmpty(array);


            //***///InRange/NotInRange
            //Değerin aralıkta olup olmadığı kontrol edilir.
            //10 değeri 2 ile 20 arasında mı?
            //Assert.InRange(10, 2, 20);
            //Assert.NotInRange(30, 2, 20);

            //***///Single
            //bir dizinin içerisinde bir alaman var ise true
            //eğer eleman yok veya birden fazla eleman var ise false döner.
            //Assert.Single(new List<string> { "aa"});

            //***///IsType/IsNotType
            //Assert.IsType<string>("dd");
            //Assert.IsType<int>(12);


            //***///IsAssignableFrom
            //bir tipin bir tipe referans verip veremeyeceğini kontrol eder
            //miras alınıp alınmadığı , bir interfaceyi implemente edip etmediğini
            //test etmek için kulllanılır
            //Assert.IsAssignableFrom<IEnumerable<string>>(new List<string>());
            //Assert.IsAssignableFrom<Object>("aa");

           
            //***///Null/NotNull
            //Assert.Null(null);
            //Assert.NotNull("");


            //***///Equal/NotEqual
            //Assert.Equal(10,10);
            //Assert.NotEqual("11","12");


        }
        //Parametreli Test Fonksiyonları;
        //[Theory] attribute si ilgili methodun parametre almasını zorunlu kılar;
        //ve parametre geçilmesi için;
        //[InlineData(param-1,param-2,param-3)]
        //istediğimiz kadar inline data ile parametre gönderebiliriz;
        [Theory]
        [InlineData(2,3,5)]
        [InlineData(10, 11, 21)]
        public void test_simpleValue_returnTotalValue(int a ,int b, int expectedTotal)
        {
            //burada expectedTotal beklediğimiz değerdir.
            //aşağıdaki actual data ise gerçek methodun döndürdüğü değerdir.
            //var calculator = new Calculator();
          var actualData =  calculator.add(a, b);
            Assert.Equal(expectedTotal, actualData);
        }
        [Theory]
        [InlineData(0, 3, 0)]
        [InlineData(10, 0, 0)]
        public void test_zeroValue_returnTotalValueZero(int a, int b, int expectedTotal)
        {
            var actualData = calculator.add(a, b);
            Assert.Equal(expectedTotal, actualData);
        }
    }

    }
