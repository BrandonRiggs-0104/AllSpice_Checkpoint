using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllSpice_Checkpoint.Models
{
    public class recipes
    {
    public int Id { get; set; }
    public string Title { get; set; }
    public string Instructions { get; set; }
    public string Img { get; set; }
    public string Category { get; set; }
    public string CreatorId { get; set; }
    public Profile Creator { get; set; }
    }
}