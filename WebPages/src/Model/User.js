export default class User{

    constroctur(name,pwd,url){
        this.name= name != null ? name : "b" ;
        this.pwd= pwd != null ? name : "a" ;
    }

    Login(successFunc) {
        fetch("http://localhost:5000/User/Login",{
            method:"post",
            body:{
                UserName:'Fan',
                UserPwd:'GuoDong'
            }
        })
        .then((res)=>{
            return res.json();
        })
        .then((json)=>{
            console.log(json);
            if(successFunc!=null) successFunc();
        })
    }
}