using System.Collections.Generic;

namespace Book_Store.MVVM.Model
{
    /// <summary>
    /// Describes the readable type.
    /// </summary>
    public abstract class Readable
    {
        /// <summary>
        /// Id of the readable object.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Title of the readable object.
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// Author of the readable object.
        /// </summary>
        public string? Author { get; set; }

        /// <summary>
        /// Genre of the readable object.
        /// </summary>
        public string? Genre { get; set; }

        /// <summary>
        /// Description of the readable object.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Cover of the readable object.
        /// </summary>
        public string? Cover { get; set; }

        /// <summary>
        /// Amount of pages or articles in the readable object.
        /// </summary>
        public int ContentCount { get; set; }

        /// <summary>
        /// Amount of readable in library.
        /// </summary>
        public int AmountInLibrary { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int AmountInCart { get; set; }

        /// <summary>
        /// Price of the readable object.
        /// </summary>
        /// <returns></returns>
        public abstract decimal Price { get; }

        //public List<Library> Libraries { get; set; }
    }
}
