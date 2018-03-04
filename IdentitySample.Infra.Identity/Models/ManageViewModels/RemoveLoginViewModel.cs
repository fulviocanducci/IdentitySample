using System;
using System.Collections.Generic;
using System.Text;

namespace IdentitySample.CrossCutting.Identity.Models.ManageViewModels
{
  public  class RemoveLoginViewModel
    {
        public string LoginProvider { get; set; }
        public string ProviderKey { get; set; }
    }
}
