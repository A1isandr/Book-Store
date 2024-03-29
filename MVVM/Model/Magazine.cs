﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Store.MVVM.Model
{
    /// <summary>
    /// Describes basic behaviour of a magazine.
    /// </summary>
    internal class Magazine : Readable
    {
		public Magazine() { }

		public Magazine(Magazine magazine)
		{
			Id = magazine.Id;
			Title = magazine.Title;
			Author = magazine.Author;
			Genre = magazine.Genre;
			Description = magazine.Description;
			Cover = magazine.Cover;
			ContentCount = magazine.ContentCount;
		}

		public override decimal Price
        {
            get
            {
                // Пример формулы: базовая цена + (цена за статью * количество статей)
                decimal basePrice = 4.99m;
                decimal pricePerArticle = 1.25m;

                return basePrice + pricePerArticle * ContentCount;
            }
        }
    }
}
