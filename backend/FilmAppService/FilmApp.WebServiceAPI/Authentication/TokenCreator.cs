// using

// class TokenCreator 
// {
//   public string GenerateJSONWebToken(UserModel userInfo)    
//         {    
//             var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));    
//             var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);    
    
//             var token = new JwtSecurityToken(_config["Jwt:Issuer"],    
//               _config["Jwt:Issuer"],    
//               null,    
//               expires: DateTime.Now.AddMinutes(120),    
//               signingCredentials: credentials);    
    
//             return new JwtSecurityTokenHandler().WriteToken(token);    
//         }    
// }