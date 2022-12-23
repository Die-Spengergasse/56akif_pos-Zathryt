using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Spg.PluePos._01.Model
{
    public class SmartPhoneApp : List<Post>
    {
        public string SmartPhoneId { get; set; } = string.Empty;

        public new void Add(Post post)
        {
            if (post != null)
            {
                base.Add(post);
                post.SmartPhone = this;
            }
        }
        public SmartPhoneApp(string smartPhoneId)
        {
            SmartPhoneId = smartPhoneId;
        }
        public string ProcessPosts()
        {
            string a = string.Empty;
            foreach (Post post in this)
            {
                a += post.Html;
            };
            return a;
        }
        public decimal CalcRating()
        {
            return this.Sum(post => post.Rating);
        }

        public Post? this[string s]
        {
            get 
            {
                foreach (Post p in this)
                {
                    if (p.Html.Contains(s)) { return p; }
                }
                return null;
            }
        }

    }
}
