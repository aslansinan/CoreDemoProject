﻿using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete;

public class Category
{
    //Erişim Belrleyici Türü - Değişken Türü isim -{get set}
    [Key]
    public int  CategoryID { get; set; }
    public string  CategoryName { get; set; }
    public string  CategoryDescription { get; set; }
    public bool  CategoryStatus { get; set; }
}