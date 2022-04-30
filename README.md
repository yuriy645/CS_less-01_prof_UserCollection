## My homework for the C# Professional course, less-01_pro_UserCollection
1. Create a method that takes an array of integers as an argument and returns
   collection of squares of all odd numbers in the array. Use the yield statement to form a collection.
2. Create a collection that would store the names of 12 months, the serial number and
   the number of days in the corresponding month. Implement the ability to select months, as in
   serial number, and the number of days in a month, while the result can be not only one month.
3. Create an abstract class Citizen. Create classes Student, Retired, Worker
   inherited from Citizen. Create a non-parameterized collection with the following functionality:
    1. Adding an element to the collection.
      1) You can only add a Citizen.
      2) When adding, the element is added to the end of the collection. If Retired, then in
         start taking into account the previously standing Pensioners. The number in the queue is returned.
      3) When adding the same person (check for equality by number
         passport, you need to override the Equals method and/or the equality operators to
         comparison of objects by passport number) the element is not added, a message is displayed.
    2. Removal
      1) Deletion - from the beginning of the collection.
      2) It is possible to delete with the transfer of a copy of the Citizen.
    3. The Contains method returns true/false if the element is present/absent in the collection and the number in the queue.
    4. The ReturnLast method returns the last person in the queue and their number in the queue.
    5. The Clear method clears the collection.
    6. You can work with the collection using the foreach operator.
