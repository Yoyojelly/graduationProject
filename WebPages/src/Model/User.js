export default class User{

    constroctur(name,pwd){
        this.name= name != null ? name : "b" ;
        this.pwd= pwd != null ? name : "a" ;
    }

    Login(successFunc) {
        fetch("https://localhost:5001/User/Login",{
            method:"POST",
            // 必须声明是json
            headers: {
                'Content-Type': 'application/json'
              },
            //   必须经过序列化
            body:JSON.stringify({
                UserName:this.name,
                UserPwd:this.pwd
            })
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