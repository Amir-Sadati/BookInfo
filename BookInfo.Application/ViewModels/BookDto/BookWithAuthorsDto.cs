using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BookInfo.Application.ViewModels.BookDto
{
   public class BookWithAuthorsDto
    {
       
        [JsonIgnore]
        public List<authorbookdto> BookAuthors { set; get; }
        [JsonPropertyName("نام کتاب")]
        public string BookName { set; get; }
        
        [JsonPropertyName("نام نویسندگان")]
        public string NameFamily { get
       
            {
                var namefamily = "";
                foreach(var item in BookAuthors)
                {
                    if (namefamily == "")
                        namefamily = $"{item.AuthorName} {item.AuthorFamily}";
                    else
                        namefamily = $"{namefamily}- {item.AuthorName} {item.AuthorFamily}";
                }
                return namefamily;
            }
        
        }

        

      
    


    }
}
