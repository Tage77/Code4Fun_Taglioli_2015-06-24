using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

/*
 * Test project using Visual Studio 2012 (C#) NUnit test framework
 */
namespace Intersection_Test
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using NUnit.Framework;

    public class Manage_Array_List
    {

        /*A. Implement a function that returns the intersection of two sorted arrays, assuming numbers in
             each array are unique and array lengths can be different.
             For example, given the two sorted arrays {1, 14, 7, 20, 33} and {1, 32, 51, 7, 99}, the function
             should return the intersection array {1, 7}.*/

        /*-----------------------------------------------*/
        /* Function - Intersection of two sorted arrays */
        /*--------------------------------------------- */
        public int[] Intersection_Array(int[] Array_first, int[] Array_second)
        {
            //Define the array with the intersection
            int[] Intersection = { };

            //Find Array lenght
            int first_size = Array_first.Length;
            int second_size = Array_second.Length;

            //Nested cicle to find for every number in first_array the same number in second array 	
            for (int i = 0; i <= first_size - 1; i++)
            {
                for (int j = 0; j <= second_size - 1; j++)
                {
                    if (Array_first[i] == Array_second[j])
                    {
                        //Resize the intersection array
                        Array.Resize(ref Intersection, Intersection.Length + 1);

                        //Fill the intersection array
                        Intersection[Intersection.Length - 1] = Array_first[i];
                    }
                }
            }

            //Return the intersection array
            return Intersection;
        }

        /*B. Without using framework provided methods such as Count, Getlem or similar, write a method 
             which would return the Nth element from the end of a generic type singly linked list, in one pass.
             The method will take 2 parameters:
             - the index N from the end of the list 
             - the generic singly linked list 
             For example, given N = 5 and the list of integers {82, 55, 78, 92, 12, 44, 51}, the method should return 78.

        /*--------------------------------------*/
        /* Function - Get Nth value from list   */
        /*-------------------------------------*/
        public int GiveValue(int fromEnd, List<int> theList)
        {
            //Create temp var
            int k = 0;
            int value = 0;

            //If fromEnd > list size throw exception throw exception
            if (fromEnd >= theList.Count)
            {
                throw new ArgumentOutOfRangeException("Invalid parameters");
            }
            else
            {
                //Verify the Nth position from End
                while (k != theList.Count)
                {
                    if (k == theList.Count - fromEnd)
                    {
                        value = theList[k];
                    }
                    k++;
                }
            }

            return value;
        }
    }


    [TestFixture]
    public class Manage_Array_List_Test
    {
        //Create an istance for test      
        private Manage_Array_List general = new Manage_Array_List();

        //Test for Intersection fuction  
        [Test]
        public void Intersection_Test()
        {
            //Generic int array for test
            int[] First = { 1, 14, 7, 51, 33, 12, 13, 88, 99, 121, 123, 122, 124 };
            int[] Second = { 88, 1, 32, 52, 7, 99, 125 };
            int[] Expected_Result = { 1, 7, 88, 99 };

            //Execute function
            int[] Result = general.Intersection_Array(First, Second);

            //Check result
            Assert.AreEqual(Expected_Result, Result);
        }

        //Test for Nth value from end
        [Test]
        public void GiveValue_Test()
        {
            //Create a list for test N=4
            List<int> lst = new List<int> { 5, 16, 22, 134, 24 };
            int val = general.GiveValue(4, lst);

            //Check result
            Assert.AreEqual(16, val);
        }

        //Test for argument out of range exception
        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void OutofRangeException_Test()
        {
            //Index value N=8 out of range 
            List<int> lst = new List<int> { 5, 16, 22, 134, 24 };
            int val = general.GiveValue(8, lst);

        }
    }

}

