using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
	public class MovieFormViewModel
	{
		public IEnumerable<Genre> Genres { get; set; }
		public int Id { get; set; }
		[Required]
		[MaxLength(225)]
		public string Name { get; set; }
		[Required]
		[Display(Name = "Genre")]
		public byte GenreId { get; set; }

		[Display(Name = "Release Date")]
		public DateTime ReleaseDate { get; set; }
		[Display(Name = "Number in Stock")]
		[Range(1, 20)]
		[Required]
		public byte NumberInStock { get; set; }

		public string Title
		{
			get { return Id != 0 ? "Edit Movie" : "New Movie"; }
		}
		public MovieFormViewModel()
		{
			
		}

		public MovieFormViewModel(Movie movie)
		{
			Id = movie.Id;
			Name = movie.Name;
			GenreId = movie.GenreId;
			ReleaseDate = movie.ReleaseDate;
			NumberInStock = movie.NumberInStock;
		}
	}
}