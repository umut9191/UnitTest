using Moq;
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
        public Calculator? calculator { get; set; }
        Mock<ICalculatorService> myMock  { get; set; }

    public CalculatorTest()
        {
            myMock = new Mock<ICalculatorService>();
            calculator = new Calculator(myMock.Object);
            //calculator = new Calculator(new CalculatorService());
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
          var actualData =  calculator?.add(a, b);
            Assert.Equal(expectedTotal, actualData);
        }
        [Theory]
        [InlineData(0, 3, 0)]
        [InlineData(10, 0, 0)]
        public void test_zeroValue_returnTotalValueZero(int a, int b, int expectedTotal)
        {
            var actualData = calculator?.add(a, b);
            Assert.Equal(expectedTotal, actualData);
        }

        //Mock ile test etme;
        [Theory]
        [InlineData(2, 3, 5)]
        [InlineData(10, 11, 21)]
        public void test_simpleValue_returnTotalValue_viaMock(int a, int b, int expectedTotal)
        {
          //Methoda ne parametre değerleri gelirse gelsin ben bu methodu taklit ediyorum
          //ve benim burada belirlediğim değer dönsün
            myMock.Setup(x => x.add(a, b)).Returns(expectedTotal);
            var actualData = calculator?.add(a, b);
            Assert.Equal(expectedTotal, actualData);
            myMock.Verify(x => x.add(a, b),Times.Once);//bu method 1 defa çalışırsa
                                                       // test başarılı olur ancak eğer hiç çalışmaz ise ya da birden çok çalışır
                                                       // ise test başarısız sonuçlanacaktır. 

            //  myMock.Verify(x => x.add(a, b), Times.AtLeast(2));
            //myMock.Verify(x => x.add(a, b), Times.AtMost(2));
        }
        [Theory]
        [InlineData(2, 3, 6)]
        public void test_simpleMultipleValue_returnTotalValue_viaMock(int a, int b, int expectedTotal)
        {
            myMock.Setup(x => x.multip(a, b)).Returns(expectedTotal);
            var actualData = calculator?.multip(a, b);
            Assert.Equal(expectedTotal, actualData);
        }
        ///Moq un Throws methodunu kullanalım;
        [Theory]
        [InlineData(0, 3)]
        public void test_zeroMultipleValue_returnTotalValue_viaMockThrows(int a, int b)
        {
            myMock.Setup(x => x.multip(a, b)).Throws(new Exception("a=0 olamaz"));
          Exception exception =  Assert.Throws<Exception>(() => calculator?.multip(a, b));
            Assert.Equal("a=0 olamaz", exception.Message);
        }
        //use callBack and It.IsAny<type>
        [Theory]
        [InlineData(2, 3, 6)]
        public void test_simpleMultipleValue_returnTotalValue_viaMockCallBackAndItIsAny(int a, int b, int expectedTotal)
        {
            //myMock.Setup(x => x.multip(a, b)).Returns(expectedTotal);
            //var actualData = calculator?.multip(a, b);
            //Assert.Equal(expectedTotal, actualData);
            //Assert.Equal(expectedTotal, calculator?.multip(3, 4));//Bunun mock setup ı yapılmadığından
            //hata verecek biz burada bu yapıyı bu şekilde sağlayacağız;
            int actualMultiple=0;
            myMock.Setup(x => x.multip(It.IsAny<int>(), It.IsAny<int>()))
                .Callback<int,int>((x,y)=>actualMultiple= x*y);
            calculator?.multip(a, b);           
            Assert.Equal(expectedTotal, actualMultiple);
            //bu aşağıdakileri inlinaData içerisinde vermeden burada bu şekilde kullanabildik;
             calculator?.multip(3, 5);
            Assert.Equal(15, actualMultiple);
        }
    }

    }
//Mock class ya da interfacelerin davranışlarını
//taklit etmek için kullanılan objelerdir.
//Dış kaynaktan test edilecek methoda hizmet sağlıyorsak
//burada dış kaynağa gerçek bir request yapmak yerine unit test lerde mock kullanılır;
//Amaç;
//Dış kanak iletişimin alacağı zamanı test methodlarının çalışmasında harcamamak
//Her yazılmış projede unit test methodları eklenebilir fakat mock her projeye eklenemez.
//Bir projeye mock kullanımı eklenmesi için;
//Proje
//Dependency injection
//Abstraction
//yapıları kullanılarak geliştirilmiş olmalı.


//Mock lar el ile manuel oluşturulabilir ayrıca
//Moq Framework ü kullanılarak otomatik oluşturulabilirler
//unit test projesine manage nugget package den yüklüyoruz Moq(Daniel Cazzulino)

//Moq Framewok ü nünde Xunit te olduğu gibi methodları var ;
//Verify() methodu bir methodun çalışıp çalışmadığını ve çalıştıysa kaç defa çalıştığını
//test etmemize olanak tanır.

//Throws() örneğin servisten dönebilecek hataların dönmesini simüle edebiliyoruz
//durumlara göre dönecek hataların doğru olup olmadığını test etmemize olanak tanır.

//callBack() 
//simüle edeceğimiz method çalıştığı
//zaman arka tarafta bir callBack methodu çalıştırabiliriz.
//extra bir method daha çalıştırmak anlamına geliyor.

//It.IsAny<type>
//simüle edeceğimiz method sadece int parametresi alırsa çalışsın ya da
//örneğin string parametresi alırsa şu değerler dönsün diyebiliriz.