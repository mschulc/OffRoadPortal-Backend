/////////////////////////////////////////////////////////////
// Off-Road Portal WebApi                                  //
// Bachelor's thesis software                              //
// Author and software owner Maciej Schulc                 //
// All rights reserved ®                                   //
// File: IUserService.cs                                   //
/////////////////////////////////////////////////////////////

using OffRoadPortal.Models;

namespace OffRoadPortal.Interfaces;

public interface IUserService
{
    void UpdateProfileImage(long id, string path);
    public void Update(UpdateUserDto dto);
}