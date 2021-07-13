﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AspNetKurumsalWeb.Models.Model
{
    [Table("Yorum")]
    public class Yorum
    {
        public int YorumId { get; set; }
        [Required,StringLength(50,ErrorMessage ="50 karakter olabilir")]
        public string AdSoyad { get; set; }

        public string Eposta { get; set; }

        [DisplayName("Yorumunuz")]
        public string Icerik { get; set; }
        public int? BlogId { get; set; }

        // blog tablosundan bir kayıt gelecek demek
        public Blog Blog { get; set; }


    }
}


