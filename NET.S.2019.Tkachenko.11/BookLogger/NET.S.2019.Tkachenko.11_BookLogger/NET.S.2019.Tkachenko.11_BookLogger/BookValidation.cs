namespace NET.S._2019.Tkachenko._11
{
    using System;
    using NLog;

    public static class BookValidation
    {
        private static readonly Logger bookLogger = LogManager.GetCurrentClassLogger();

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
                bookLogger.Error($"There was a null string in book description.");
                throw new ArgumentNullException("Null string was found.");
            }

            if (isbn <= 0 || edition <= 0 || editionYear <= 0 || pages <= 0 || price < 0)
            {
                bookLogger.Error($"There was an invalid number in book description. ISBN: {isbn}; Edition: {edition}; Edition year: {editionYear}; Number of pages: {pages}; Price: {price};");
                throw new ArgumentException("Invalid number was found.");
            }

            if (name == string.Empty || author == string.Empty)
            {
                bookLogger.Error($"There was an empty string in book description.");
                throw new ArgumentException("Empty string was found.");
            }
        }
    }
}