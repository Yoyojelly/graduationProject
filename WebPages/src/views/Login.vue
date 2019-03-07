<template>
    <div id="LoginDiv">

        <el-row>
            <el-col class="LoginForm" :span="6" :offset="13">
                <p class="LoginTitle">登陆</p>
                <!-- 表单 -->
                <el-form :model="LoginUser" status-icon ref="LoginUser">
                    <!-- 帐号 -->
                    <el-form-item prop="name" required>
                        <el-input type="text" v-model="LoginUser.name" autocomplete="off">
                            <template slot="prepend">
                                <i class="el-icon-service"></i>
                            </template>
                        </el-input>
                    </el-form-item>
                    <!-- 密码 -->
                    <el-form-item prop="pwd" required>
                        <el-input type="password" v-model="LoginUser.pwd" autocomplete="off">
                            <template slot="prepend">
                                <i class="el-icon-question"></i>
                            </template>
                        </el-input>
                    </el-form-item>
                    <!-- 提交 -->
                    <el-form-item required>
                        <el-button class="commitBtn" type="primary" @click="submitForm()">提交</el-button>
                    </el-form-item>
                </el-form>
            </el-col>
        </el-row>
    </div>
</template>

<script>
    import User from "../Model/User.js";

    export default {
        data() {
            return {
                LoginUser: new User()
            }
        },
        methods: {
            submitForm() {
                this.$message("正在执行");
                this.LoginUser.Login(
                    ()=>{
                        this.$message("成功");
                    }
                );
            }
        }
    }
</script>

<style scoped>
    #LoginDiv {
        position: fixed;
        width: 100%;
        height: 100%;
        margin-left: -0.6%;
        margin-top: -1.2%;
        background: linear-gradient(to top right, #369CFA, #3171DC);
    }

    .LoginForm {
        margin-top: 8%;
        /* box-shadow: 0 2px 4px rgba(0, 0, 0, .12), 0 0 6px rgba(0, 0, 0, .04);
        border: 1px;
        border-radius: 2px; */
    }

    .LoginTitle {
        text-align: center;
        font-size: 30px;
        color: white;
        font-family: PingFang SC;
    }

    .commitBtn {
        width: 100%;
    }
</style>
