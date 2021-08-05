import React, { useState, useEffect, useCallback } from "react"
import Layout from "./layout"
import Header from "./header"
import { navigate } from "gatsby"
import icon_left_arrow from "../images/icon_left_arrow.png"
import icon_right_arrow from "../images/icon_right_arrow.png"
import { IconButton } from "@material-ui/core"

const Main  = () => {
    return (
        <Layout>
            <Header image="이미지">
            </Header>
        <section style={{
            backgroundColor: "#161C24",
            display: "flex",
            width: "100%",
            height: "950px",
            flexDirection : 'column',
            alignItems: "center",
            justifyContent: "center",
        }}>
            <div style={{display : 'flex' , flexDirection : 'column', marginRight : '50px'}}>
                <p style={{ color: "#fff", fontSize: "50px", fontFamily: "Noto Sans KR", fontWeight: 700, lineHeight: "10px", letterSpacing: "-1.08px"}}>
                    AMAZING FOR EVERYONE
                </p>
                <p style={{ marginLeft : '150px', color: "#fff", fontSize: "26px", fontFamily: "Noto Sans KR", fontWeight: 400, lineHeight: "40px"}}>
                    We are a digital play production partner for global clients.<br></br>
                    We produce premium quality interactive experiences that<br></br>
                    reach audiences on all platforms. Meaningful connections<br></br>
                    between brands and engaged consumers, wherever they<br></br>
                    are, however they connect.
                </p>
                <div style={{marginLeft : '150px'}}>
                <p style={{color: "#fff", fontSize: "20px", fontFamily: "Noto Sans KR", fontWeight: 400, lineHeight: "40px"}}>
                    FIND OUT MORE
                </p> 
                    <IconButton style={{display : "flex", padding : 0}}>
                        <img style={{width : "30px", height : "30px"}} src={icon_right_arrow} alt={"오른쪽화살표"}></img>
                    </IconButton>
                </div>
            </div>
            
        </section>

        <section style={{
            backgroundColor: "#fff",
            display: "flex",
            width: "100%",
            height: "900px",
            justifyContent: "center",
            alignItems: "center",
        }}>
            <div>
                core
            </div>
        </section>

        <section style={{
            backgroundColor: "#fff",
            display: "flex",
            width: "100%",
            height: "900px",
            justifyContent: "center",
            alignItems: "center",
        }}>
            <div>
                link
            </div>
        </section>

        <section style={{
            backgroundColor: "#fff",
            display: "flex",
            width: "100%",
            height: "900px",
            justifyContent: "center",
            alignItems: "center",
        }}>
            <div>
                contact us
            </div>
        </section>

        </Layout>
    )
}

export default Main;