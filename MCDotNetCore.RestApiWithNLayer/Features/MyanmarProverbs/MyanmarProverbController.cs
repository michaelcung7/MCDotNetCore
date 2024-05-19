﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MCDotNetCore.RestApiWithNLayer.Features.MyanmarProverbs;

[Route("api/[controller]")]
[ApiController]
public class MyanmarProverbController : ControllerBase
{
    private async Task<Tbl_Mmproverbs> GetDataFromApi()
    {
      //  HttpClient client = new HttpClient();
        //var response =await client.GetAsync("https://github.com/sannlynnhtun-coding/Myanmar-Proverbs/blob/main/MyanmarProverbs.json");
       
       // if (response.IsSuccessStatusCode)
        //{
            //string jsonStr =await response.Content.ReadAsStringAsync();
        //    var result = JsonConvert.DeserializeObject<Tbl_Mmproverbs>(jsonStr);
        //    return result;
        //}
        //return null;
        string jsonStr = await System.IO.File.ReadAllTextAsync("MyanmarProverbs.json");
        var result = JsonConvert.DeserializeObject<Tbl_Mmproverbs>(jsonStr);
        return result;
    }

    [HttpGet]
    public async Task<IActionResult> GetList()
    {
        var model =await GetDataFromApi();
        return Ok(model.Tbl_MMProverbsTitle);
    }

    [HttpGet("{titleName}")]
    public async Task<IActionResult> Get(string titleName)
    {
        var model = await GetDataFromApi();
        var item = model.Tbl_MMProverbsTitle.FirstOrDefault(x => x.TitleName == titleName);
        if (item is null) return NotFound("No Data Found");
        int titleId = item.TitleId;
        var result = model.Tbl_MMProverbs.Where(x => x.TitleId == titleId);
        List<Tbl_MmproverbHead> lst = result.Select(x => new Tbl_MmproverbHead
        {
            TitleId = x.TitleId,
            ProverbId = x.ProverbId,
            ProverbName = x.ProverbName

        }).ToList();
        return Ok(lst);
    }

    [HttpGet("{titleId}/{proverbId}")]
    public async Task<IActionResult> GetDataById(int titleId, int proverbId)
    {
        var model = await GetDataFromApi();
        var item = model.Tbl_MMProverbs.FirstOrDefault(x => x.TitleId == titleId && x.ProverbId == proverbId);
        if (item is null) return NotFound("No Data Found");
        return Ok(item);
    }

}

public class Tbl_Mmproverbs
{
    public Tbl_Mmproverbstitle[] Tbl_MMProverbsTitle { get; set; }
    public Tbl_MmproverbDetail[] Tbl_MMProverbs { get; set; }
}

public class Tbl_Mmproverbstitle
{
    public int TitleId { get; set; }
    public string TitleName { get; set; }
}

public class Tbl_MmproverbHead
{
    public int TitleId { get; set; }
    public int ProverbId { get; set; }
    public string ProverbName { get; set; }
}

public class Tbl_MmproverbDetail
{
    public int TitleId { get; set; }
    public int ProverbId { get; set; }
    public string ProverbName { get; set; }
    public string ProverbDesp { get; set; }
}

