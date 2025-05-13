using Domain.DTOs;
using Domain.Entities;

namespace Domain.Interfaces.Service;

public interface IUrlService
{
    UrlEntity Post(UrlPostDto urlPostDto);
}
