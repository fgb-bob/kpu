import React, { useState, useEffect, useCallback } from "react"
import styled from "styled-components"
import Layout from "../../components/layout"
import Header from "../../components/header"
import { navigate } from "gatsby"
import { IconButton } from "@material-ui/core"
import Banner from "../../components/banner"
import contact_map from "../../images/contact_map.jpg"
import CategoryImage from "../../components/CategoryImage"
import GamesLink from "../../components/GamesLink"
import maccas_casestudy_firstframe from "../../images/maccas_casestudy_firstframe.png"
import Paddington from "../../images/Paddington_Casestudy_Firstframe1.jpg"
import logo_html5 from "../../images/about/logo-html5-2.png"
import logo_webgl from "../../images/about/logo-webgl.png"
import logo_pixijs_v5 from "../../images/about/pixijs_v5.png"
import logo_unity from "../../images/about/unity.png"
import usp_platforms from "../../images/usp_platforms.png"
import usp_brand from "../../images/usp@1x_brand.png"
import usp_measure from "../../images/usp@1x_measure.png"
import parallax1 from "../../images/parallax-1.png"
import parallax2 from "../../images/parallax-2.png"
import bullet_html5 from "../../images/bullet@2_html5.png"
import bullet_23d from "../../images/bullet@2_23d.png"
import bullet_brand from "../../images/bullet@2_brand.png"
import bullet_multi from "../../images/bullet@2_multi.png"
import bullet_game from "../../images/bullet@2_gameapp.png"
import bullet_educate from "../../images/bullet@2_educate.png"
import bullet_lenses from "../../images/bullet@2_lenses-1.png"
import bullet_xr from "../../images/bullet@2_xr.png"


const Games = (props) =>{

    const [num, setNum] = useState(0)

  
    const imgStlye={
        width: '20%',
        height:'100%'
    }

    const imgStlye2={
        width: '5%',
        height: `5%`
    }
    
    return(
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
                backgroundColor: "#3F51B5",
                display: "flex",
                width: "100%",
                height: "100%",
                justifyContent: "center",
                alignItems: "center",
                flexDirection : 'column'
                }}>
                <div style={{height : '100px'}}></div>
                <div style={{display : 'flex', justifyContent :'space-around',alignItems :'center', flexDirection : 'row', width : '80%'}}>
                    <DivStlye1>
                        <img src={usp_platforms} alt ={'platforms'} style={imgStlye}></img>
                        <TextStyle1>CROSS PLATFORM</TextStyle1>                
                        <TextStyle2>We make games in HTML5 that live on everything, everywhere because that’s where your audiences are.</TextStyle2>
                    </DivStlye1>

                    <DivStlye1>
                        <img src={usp_brand} alt ={'platforms'} style={imgStlye}></img>
                        <TextStyle1>ON-BRAND</TextStyle1>
                        <TextStyle2>Using brands as meaningful enhancements to play, that add value to experiences rather than diluting them.</TextStyle2>
                    </DivStlye1>

                    <DivStlye1>
                        <img src={usp_measure} alt ={'platforms'} style={imgStlye}></img>
                        <TextStyle1>MEASURED</TextStyle1>
                        <TextStyle2>Game data tracking means KPI, ROI, DAU and all aspects of performance can be monitored and refined even whilst live.</TextStyle2>
                    </DivStlye1>
                </div>
                    
                
                <div style={{height : '100px'}}></div>
            </section>
        
            <section style={{
                    backgroundColor: "#252C39",
                    display: "flex",
                    width: "100%",
                    height: "100%",
                    flexDirection : 'column',
                    alignItems: "center",
                    justifyContent: "center",
                }}>
                <div style={{height : '50px'}}></div>
                <p style={{color : "#fff", fontSize : "15px"}}>_OUR CLIENTS</p>
                    <Banner></Banner>
                <div style={{height : '50px'}}></div>
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
                <DivStlye3>
                    <TextStyle3>PLAYING FOR KEEPS</TextStyle3>
                    <TextStyle4>Whilst games are great fun for audiences, for us they are a serious business. When you attach your brand, services or products to them, they have to be meaningful and considered. And sure, great fun too!</TextStyle4>
                    <TextStyle5>The first step comes from identifying the strategic motivation to make a game and then to understand the audience we will be talking to. Knowing the why and the who leads to the what - what kind of game experience delivers the message required to the relevant players.</TextStyle5>
                    <TextStyle5>Decades of combined experience in answering these questions means that we can provide expert guidance on how different demographics play and what best meets their needs. This covers everything from the theme and genre to interaction methods and feedback.</TextStyle5>
                    <TextStyle5>Behind all the strategy, methodology and rigour in their creation, our games all share one vital strand of DNA - they’re absolutely awesome fun to play! Making the right game, with the right message for the right player is valuable. Do all that and make it fun too and it’s vital.</TextStyle5>
                    <TextStyle5>Games for everyone.</TextStyle5>
                </DivStlye3>

                <div style={{width : '100%',height : "100%"}}>
                    <img style={{width: '60%', height : '100%',marginLeft:'10%'}} src={parallax1}></img>
                    <img style={{width: '100%', height : '100%',marginTop : '-28%'}} src={parallax2}></img>
                </div>

                
                <div style={{height : '50px'}}></div>
            </section>
            
            <section style={{
                backgroundColor: "#3F51B5",
                display: "flex",
                width: "100%",
                height: "100%",
                flexDirection : 'column',
                alignItems: "center",
                justifyContent: "center",
            }}>
                <div style={{height : '50px'}}/>
                <TextStyle3 marginLeft={`0%`}>Goodboy Games Services</TextStyle3>
                <DivStlye2>
                    <DivStlye2>
                        <img style={imgStlye2} src={bullet_html5} alt={'html5'}></img>
                        <TextStyle6>HTML5 Games</TextStyle6>
                    </DivStlye2>

                    <DivStlye2>
                        <img style={imgStlye2} src={bullet_23d} alt={'23d'}></img>
                        <TextStyle6>2D / 3D Games</TextStyle6>
                    </DivStlye2>

                    <DivStlye2>
                        <img style={imgStlye2} src={bullet_brand} alt={'brand'}></img>
                        <TextStyle6>Brand Games</TextStyle6>
                    </DivStlye2>
                </DivStlye2>

                <DivStlye2>
                    <DivStlye2>
                        <img style={imgStlye2} src={bullet_multi} alt={'multi'}></img>
                        <TextStyle6>Multiplayer</TextStyle6>
                    </DivStlye2>

                    <DivStlye2>
                        <img style={imgStlye2} src={bullet_game} alt={'game'}></img>
                        <TextStyle6>Games Apps</TextStyle6>
                    </DivStlye2>

                    <DivStlye2>
                        <img style={imgStlye2} src={bullet_educate} alt={'educate'}></img>
                        <TextStyle6>Kids / Educational Web Games</TextStyle6>
                    </DivStlye2>
                </DivStlye2>

                <DivStlye2>
                    <DivStlye2>
                        <img style={imgStlye2} src={bullet_lenses} alt={'lenses'}></img>
                        <TextStyle6>Facebook/Snapchat Games</TextStyle6>
                    </DivStlye2>

                    <DivStlye2>
                        <img style={imgStlye2} src={bullet_xr} alt={'xr'}></img>
                        <TextStyle6>XR (AR/VR) Games</TextStyle6>
                    </DivStlye2>
                </DivStlye2>


            <div style={{height : '50px'}}></div>

        </section>

        <section style={{
                backgroundColor: "#252C39",
                display: "flex",
                width: "100%",
                height: "100%",
                flexDirection : 'column',
                alignItems: "center",
                justifyContent: "center",
            }}>
            <div style={{height : '50px'}}></div>
            <div style={{width : '80%', height : '100%',display: 'flex',flexDirection : 'row'}}>
                <GamesLink></GamesLink>
            </div>
            <div style={{height : '50px'}}></div>
            
        </section>
            
        </Layout>
    )
}

const DivStlye1 = styled.div`
    width : 25%;
    height: 100%;
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
`;

const DivStlye2 = styled.div`
    width : 100%;
    height: 100%;
    display: flex;
    flex-direction: row;
    align-items: center;
    justify-content: center;
`;

const DivStlye3 = styled.div`
    width : 100%;
    height: 100%;
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
`;

const TextStyle1 = styled.p`
    color : #fff;
    font-Size: 30px;
    font-Family: "Noto Sans KR";
    font-Weight: 600;
    line-Height: 40px;
    text-Align : center;
`;

const TextStyle2 = styled.p`
    color : #fff;
    font-Size: 25px;
    font-Family: "Noto Sans KR";
    font-Weight: 400;
    line-Height: 40px;
    text-Align : center;
    margin-top: -5%;
`;

const TextStyle3 = styled.p`
    color : #fff;
    font-Size: 60px;
    font-Family: "Noto Sans KR";
    font-Weight: 800;
    line-Height: 40px;
    text-Align : center;
    margin-left: ${props=>props.marginLeft || `-20%`};
`;

const TextStyle4 = styled.p`
    width: 35%;
    color : #fff;
    font-Size: 25px;
    font-Family: "Noto Sans KR";
    font-Weight: 400;
    line-Height: 40px;
    margin-top: -1%;
    margin-left: 10%;
`;

const TextStyle5 = styled.p`
    width: 35%;
    color : #fff;
    font-Size: ${props=>props.fontSize || 18};
    font-Family: "Noto Sans KR";
    font-Weight: ${props=>props.fontWeight || 100};
    line-Height: 22px;
    margin-left: 10%;
`;

const TextStyle6 = styled.p`
    width: 35%;
    color : #fff;
    font-Size: 25px;
    font-Family: "Noto Sans KR";
    font-Weight: 400;
    line-Height: 22px;
    white-space: nowrap;
    margin-left: 2%;
`;


export default Games

