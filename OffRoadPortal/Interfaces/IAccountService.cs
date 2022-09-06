/////////////////////////////////////////////////////////////
// Off-Road Portal WebApi                                  //
// Bachelor's thesis software                              //
// Author and software owner Maciej Schulc                 //
// All rights reserved ®                                   //
// File: IAccountService.cs                                //
/////////////////////////////////////////////////////////////

using OffRoadPortal.Models;

namespace OffRoadPortal.Interfaces
{
    public interface IAccountService
    {
        void RegisterUser(RegisterUserDto dto);
        public UserTokenDto LoginUser(LoginUserDto dto);
    }
}