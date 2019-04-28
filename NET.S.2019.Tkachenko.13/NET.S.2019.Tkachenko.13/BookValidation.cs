namespace NET.S._2019.Tkachenko._13
{
    using System;

    public static class BookValidation
    {
        /// <summary>
        /// Checks if the input for the new book was valid
        /// </summary>
        /// <param name="isbn">Isbn</param>
        /// <param name="author">Author</param>
        /// <param name="name">Name</param>
        /// <param name="edition">Edition</param>
        /// <param name="editionYear">Edition year</param>
        /// <param name="pages">Number of pages</param>
        /// <param name="price">Price</param>
        public static void CheckInput(int isbn, string author, string name, int edition, int editionYear, int pages, double price)
        {
            if (name == null || author == null)
            {
                throw new ArgumentNullException("Null string was found.");
            }

            if (isbn <= 0 || edition <= 0 || editionYear <= 0 || pages <= 0 || price < 0)
            {           
                throw new ArgumentException("Invalid number was found.");
            }

            if (name == string.Empty || author == string.Empty)
            {
                throw new ArgumentException("Empty string was found.");
            }
        }
    }
}