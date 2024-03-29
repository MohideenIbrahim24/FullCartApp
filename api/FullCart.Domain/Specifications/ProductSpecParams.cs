﻿namespace FullCart.Domain;

public class ProductSpecParams
{
    private const int MaxPageSize = 50;
    public int pageIndex { get; set; } = 1;
    private int _pageSize = 6;
    public int pageSize
    {
        get => _pageSize;
        set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
    }
    public Guid? brandId { get; set; }
    public Guid? categoryId { get; set; }
    public string sort { get; set; }
    public string _search;
    public string search
    {
        get => _search;
        set => _search = value.ToLower();
    }
}
