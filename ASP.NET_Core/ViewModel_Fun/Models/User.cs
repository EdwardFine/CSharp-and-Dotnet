#pragma warning disable CS8618
namespace ViewModel_Fun.Models;
using System.ComponentModel.DataAnnotations;

public class User{
    public string Name{get;set;}
    public User(string name){
        Name = name;
    }
}