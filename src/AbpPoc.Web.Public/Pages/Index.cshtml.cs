﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace AbpPoc.Web.Public.Pages;

public class IndexModel : AbpPocPublicPageModel
{
    public void OnGet()
    {

    }

    public async Task OnPostLoginAsync()
    {
        await HttpContext.ChallengeAsync("oidc");
    }
}
