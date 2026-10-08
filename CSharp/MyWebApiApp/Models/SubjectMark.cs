    using Microsoft.EntityFrameworkCore;
    
    namespace MyWebApiApp.Models
    {
        public class SubjectMark{
            public int id{get; set;  }
            public string Subject{get; set;  } = String.Empty;
            public int? mark{get; set;}
        }
    }  