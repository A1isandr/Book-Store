﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Store.src
{
    /// <summary>
    /// Describes the book type.
    /// </summary>
    interface IBook
    {
        /// <summary>
        /// Book's Id.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Book's name.
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Book's description.
        /// </summary>
        public string? Description { get; set; }
        /// <summary>
        /// Book's author.
        /// </summary>
        public string? Author { get; set; }
    }
}