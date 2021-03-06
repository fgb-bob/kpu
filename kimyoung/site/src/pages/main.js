import React, { useState, useEffect, useCallback } from "react"
import Layout from "../components/layout"
import Header from "../components/header"
import { navigate } from "gatsby"
import icon_left_arrow from "../images/icon_left_arrow.png"
import icon_right_arrow from "../images/icon_right_arrow.png"
import { IconButton } from "@material-ui/core"
import Banner from "../components/banner"
import contact_map from "../images/contact_map.jpg"
import CategoryImage from "../components/CategoryImage"
import CoreServices from "../components/CoreServices"
import service_logo_games from "../images/service-logo@2x-games-1.png"
import service_logo_apps from "../images/service-logo@2x-apps.png"
import service_logo_brand from "../images/service-logo@2x-brand.png"
import service_logo_multiuser from "../images/service-logo@2x-multiuser.png"
import service_logo_XR from "../images/service-logo@2x-xr-1.png"
import service_logo_kids from "../images/service-logo-kids-1.png"
import maccas_casestudy_firstframe from "../images/maccas_casestudy_firstframe.png"
import client_adobe from "../images/client/client_adobe.png"
import client_comic_relief from "../images/client/client_comic_relief.png"
import client_facebook from "../images/client/client_facebook.png"
import client_grubhub from "../images/client/client_grubhub.png"
import client_itv_sport from "../images/client/client_itv_sport-1.png"
import mob_home1_1 from "../images/mob_home1-1.jpg"


const Main  = (props) => {

    return (
        <Layout>
            <section style={{
            backgroundColor: "#161C24",
            display: "flex",
            width: "100%",
            height: "100%",
            flexDirection : 'column',
            alignItems: "center",
            justifyContent: "center",
        }}>
            <CategoryImage imageUri={maccas_casestudy_firstframe} title={"abc"} />
            
        </section>
            
        <section style={{
            backgroundColor: "#161C24",
            display: "flex",
            width: "100%",
            height: "100%",
            flexDirection : 'column',
            alignItems: "center",
            justifyContent: "center",
        }}>
            <div style={{height : '200px'}}></div>
            <div style={{display : 'flex' , height : '50%', width : `45%`}}>
                <p style={{ color: "#fff", fontSize: "52px", fontFamily: "Noto Sans KR", fontWeight: 700, lineHeight: "10px", letterSpacing: "-1.08px"}}>
                    AMAZING FOR EVERYONE
                </p>
            </div>
            <div stlye={{display : 'flex' , height : '10%', width : `100%`}}>
                <p style={{display : 'flex' , height : '100%', width : `40%`, marginLeft : '35%', color: "#fff", fontSize: "27px", fontFamily: "Noto Sans KR", fontWeight: 400, lineHeight: "40px", whiteSpace : "wordbreak"}}>
                    We are a digital play production partner for global clients.
                    We produce premium quality interactive experiences that
                    reach audiences on all platforms. Meaningful connections
                    between brands and engaged consumers, wherever they
                    are, however they connect.
                </p>
            </div>
            <div style={{display : 'flex' , height : '50%', width : `100%`}}>
                <p style={{color: "#fff", fontSize: "18px", fontFamily: "Noto Sans KR", fontWeight: 400, lineHeight: "40px", marginLeft : '35%'}}>
                    FIND OUT MORE
                </p> 
                    <IconButton
                        style={{
                            display : "flex",
                            padding : 0}}
                            onClick={()=>{
                                navigate("/about")
                            }}>
                        <img style={{width : "30px", height : "30px", marginLeft : '100%'}} src={icon_right_arrow} alt={"??????????????????"}></img>
                    </IconButton>
            </div>
            <div style={{height : '150px', width : '20%'}}></div>    
                <p style={{color : "#fff", fontSize : "15px"}}>_OUR CLIENTS</p>
            <div style={{height : '20%', width : '100%', display : 'flex', alignItems: "center", justifyContent : 'center'}}>
                <Banner></Banner>
            </div>
            <div style={{height : '20px'}}></div>
            
        </section>

        <section style={{
            backgroundColor: "#353F50",
            display: "flex",
            width: "100%",
            height: "100%",
            justifyContent: "center",
            alignItems: "center",
            flexDirection : 'column'
        }}>
            <div style={{height : '100px'}}></div>
            <div style={{width : '80%'}}>
                <CoreServices></CoreServices>
            </div>
            <div style={{height : '200px'}}></div>
        </section>

        <section style={{
            backgroundColor: "#252C39",
            display: "flex",
            width: "100%",
            height: "100%",
            justifyContent: "center",
            alignItems: "center",
        }}>
            <div style={{
                display: "flex",
                width: "80%",
                height: '100%',
                justifyContent: "center",
                alignItems: "center"}}>
                 <button
                    key={"???????????????"}
                    style={{
                        display: "flex",
                        flexDirection: "column",
                        justifyContent: "center",
                        alignItems: "center",
                        height: "fit-content",
                        width: '100%',
                        backgroundColor: '#252C39'
                    }}
                >
                <CategoryImage imageUri={maccas_casestudy_firstframe} title={"abc"}>
                    <p
                        style={{
                            color: "#fff",
                            fontSize: "80px",
                            fontFamily: "Noto Sans KR",
                            fontWeight: 800,
                            lineHeight: "18.7px",
                            letterSpacing: "-0.72px",
                            textAlign: "center",
                            whiteSpace: "nowrap",
                        }}
                    >
                        ?????????
                    </p>
                </CategoryImage>
                
            </button>
        </div>
        </section>

        <section style={{
            backgroundImage : `url(${contact_map})`,
            display: "flex",
            width: "100%",
            height: "900px",
            justifyContent: "center",
            alignItems: "center",
            flexDirection : 'column'
        }}>
            <div>
                <p style={{color: "#fff", fontSize: "100px", fontFamily: "Noto Sans KR", fontWeight: 700, lineHeight: "10px"}}>
                   Contact Us 
                </p>
            </div>

            <div style={{
               display : 'flex',
               marginRight : '0px',
               width : '800px'
            }}>
                <div style={{
                    width : '300px',
                    alignItems : 'flex-start',
                    marginRight : '0px'
                }}>
                    <p style={{color: "#fff", fontSize: "15px", fontFamily: "Noto Sans KR", fontWeight: 500}}>
                        01 _ENQUIRIES
                    </p>
                </div>
                <div>
                    <p style={{color: "#fff", fontSize: "15px", fontFamily: "Noto Sans KR", fontWeight: 500}}>
                        hello@goodboydigital.com
                    </p>
                </div> 
            </div>

            <div style={{
               display : 'flex',
               marginRight : '0px',
               width : '800px'
            }}>
                <div style={{
                    width : '300px',
                    alignItems : 'flex-start',
                    marginRight : '0px'
                }}>
                    <p style={{color: "#fff", fontSize: "15px", fontFamily: "Noto Sans KR", fontWeight: 500}}>
                        02 _PHONE
                    </p>
                </div>
                <div>
                    <p style={{color: "#fff", fontSize: "15px", fontFamily: "Noto Sans KR", fontWeight: 500}}>
                        +44 20 8533 1177
                    </p>
                </div> 
            </div>

            <div style={{
               display : 'flex',
               marginRight : '0px',
               width : '800px'
            }}>
                <div style={{
                    width : '300px',
                    alignItems : 'flex-start',
                    marginRight : '0px'
                }}>
                    <p style={{color: "#fff", fontSize: "15px", fontFamily: "Noto Sans KR", fontWeight: 500}}>
                        03 _CAREERS
                    </p>
                </div>
                <div>
                    <p style={{color: "#fff", fontSize: "15px", fontFamily: "Noto Sans KR", fontWeight: 500}}>
                        VIEW CURRENT ROLES
                    </p>
                </div> 
            </div>

            <div style={{
               display : 'flex',
               marginRight : '0px',
               width : '800px'
            }}>
                <div style={{
                    width : '300px',
                    alignItems : 'flex-start',
                    marginRight : '0px'
                }}>
                    <p style={{color: "#fff", fontSize: "15px", fontFamily: "Noto Sans KR", fontWeight: 500}}>
                        04 _FIND US
                    </p>
                </div>
                <div>
                    <p style={{color: "#fff", fontSize: "15px", fontFamily: "Noto Sans KR", fontWeight: 500, whiteSpace : "wordbreak"}}>
                        Unit B1, Matchmakers Wharf, Homerton Road, London, E9 5FF, UK
                    </p>
                </div> 
            </div>

            <div>
                
            </div>
        </section>

        </Layout>
    )
}

export default Main;