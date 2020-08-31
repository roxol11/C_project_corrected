using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quiz;
using System;
using System.Diagnostics;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestLosowanie()
        {
            bool znajdujeSie = false;
            //do zmiennej x przypisujemy wywolanie funkcji znaszego programu z argumentami 2 i 4
            //to znaczy ze losujemy liczbee z przedzialu od 2 do 4
            int x = Funkcje.losuj(2, 4);
            //inicjacja tablicy z wartosciami nwsrod ktorych bedziemy szukac
            int[] tab = { 2, 3, 4, 5 };
            //petla ktora przechodzi po wszystkich indeksach tablicy
            for (int q = 0; q < 4; q++)
            {
                //warunek sprawdzajacy czy w naszej tablicy znajduje sie wylosowana zmienna
                //jesli sie znajduje nasz amienna logiczna jest ustawiana na true w przeciwnym wypadku pozostaje false
                if (tab[q] == x)
                {
                    znajdujeSie = true;
                }
            }

            //metoda sluzaca do okreslenia czy test zostal wykonany poprawnie
            //w momencie w ktorym naszej tablicy nie bedzie znajdowala sie liczba ktora wyloswalismy zmienna znajdujeSie przyjmie wartosc false
            //tym samym funkcja IsTrue wyrzuci nam error a test zakonczy sie wynikiem negatywnym
            Assert.IsTrue(znajdujeSie, "error");
        }


        [TestMethod]
        public void TestMethod2()
        {

            //tablica zmiennych na ktorej bedziemy sprawdza� poprawno�c dzia�ania metody
            int[] tab = { 2, 3, 4, 5 };
            //do zmiennej znalaz� przypisuje warto�c jak� zwr�ci metoda search 
            // to znaczy czy w naszej tablicy znalaz�a liczbe kt�ra si� w niej znajduje 
            //przy niepoprawnym dzia�aniu metody wyrzuci�o by false i tym samym Assert.IsTrue dosta� by argument false co skutkowa�o by 
            //zako�czeniem testu z wynikiem negatywnym.
            bool znalazl = Funkcje.search(tab, tab[1]);
            Assert.IsTrue(znalazl, "error");
        }

    }

}
