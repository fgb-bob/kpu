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
import usp_easy from "../../images/usp@1x_easy.png"
import usp_integ from "../../images/usp@1x_integ.png"
import usp_aggro from "../../images/usp@1x_aggro.png"
import serv1 from "../../images/apps-serv-1.png"
import serv2 from "../../images/apps-serv-2.png"
import bullet_html5 from "../../images/bullet@2_html5.png"
import bullet_23d from "../../images/bullet@2_23d.png"
import bullet_brand from "../../images/bullet@2_brand.png"
import bullet_multi from "../../images/bullet@2_multi.png"
import bullet_game from "../../images/bullet@2_gameapp.png"
import bullet_educate from "../../images/bullet@2_educate.png"
import bullet_lenses from "../../images/bullet@2_lenses-1.png"
import bullet_xr from "../../images/bullet@2_xr.png"
import bullet_access from "../../images/bullet@2_accessibility.png"
import parallax1_2 from "../../images/parallax-1-2.png"
import parallax2_1 from "../../images/parallax-2-1.png"
import usp_auth from "../../images/usp@1x_authentic.png"
import usp_convenient from "../../images/usp@1x_convenient.png"
import usp_measure from "../../images/usp@1x_measure.png"
import usp_game from "../../images/usp@2xGAME.png"
import bullet_iterate from "../../images/bullet@2_iterate.png"
import bullet_hosting from "../../images/bullet@2_hosting.png"


const Multiuser = (props) =>{

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
                        <img src={usp_auth} alt ={'ez'} style={imgStlye}></img>
                        <TextStyle1>AFFORDABLE</TextStyle1>                
                        <TextStyle2>We have made Multiuser accessible. We offer proven, scalable plug-and-play technology to make shared experiences a viable, risk free option to all.</TextStyle2>
                    </DivStlye1>

                    <DivStlye1>
                        <img src={usp_convenient} alt ={'aggro'} style={imgStlye}></img>
                        <TextStyle1>ENGAGING</TextStyle1>
                        <TextStyle2>The phrase ‘play together, stay together’ is more than hyperbole. Experiences and games that are shared are more memorable, more compelling and more effective.</TextStyle2>
                    </DivStlye1>

                    <DivStlye1>
                        <img src={usp_measure} alt ={'integ'} style={imgStlye}></img>
                        <TextStyle1>RELEVANT</TextStyle1>
                        <TextStyle2>We offer technical and strategic support for how and why to use Multiuser solutions beyond just games. From shared campaign activities to realtime social engagement.</TextStyle2>
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
                    <TextStyle3>FOCUSSED GROUPS</TextStyle3>
                    <TextStyle4>As social dynamics change across the world and the need to find new ways to connect grows, the rise of shared digital experiences is on the precipice of exponential growth and audience relevance.</TextStyle4>
                    <TextStyle5>Our expertise in web gaming has resulted in creating flexible solutions to enable a wide range of connected, shared experiences. These solutions mean that we can now offer ‘Multiuser’ in the same way we talk about ‘3D’ or ‘gamification’. Multiuser is now another strategic option that can be adopted based solely upon the consideration of the merits it brings – this is Multiuser without expense, without complexity and most importantly, without risk.</TextStyle5>
                    <TextStyle5>Campaigns and experiences can now benefit from real-time interaction with other participants in shared spaces. Whether to play, collaborate or communicate, multiuser brings people closer together and in doing so, closer to your brands. Its potency is unquestionable – it's the difference between watching the match on your sofa or seeing that winning goal surrounded by the roar of 50,000 other people!</TextStyle5>
                    <TextStyle5>With this talk of how we can create new forms of synchronous shared experiences, rest assured when it comes to gaming we've got that covered too. We’ve created a range of multiplayer tools that mean we can bring fully scalable gaming to the web. Built using AWS systems, we can manage games that can go from hundreds of players to millions (and crucially, back again!) all without breaking a sweat, or best of all, breaking the bank!</TextStyle5>
                    <TextStyle5>Multiuser for (literally!) everyone.</TextStyle5>
                </DivStlye3>

                <div style={{width : '100%',height : "100%"}}>
                    <img style={{width: '60%', height : '100%',marginLeft:'10%'}} src={parallax1_2}></img>
                    <img style={{width: '100%', height : '100%',marginTop : '-28%'}} src={parallax2_1}></img>
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
                <TextStyle3 marginLeft={`0%`} color="white">Goodboy Apps Services</TextStyle3>
                <DivStlye2>
                    <DivStlye2>
                        <img style={imgStlye2} src={usp_game} alt={'html5'}></img>
                        <TextStyle6>Brand Games</TextStyle6>
                    </DivStlye2>

                    <DivStlye2>
                        <img style={imgStlye2} src={bullet_brand} alt={'23d'}></img>
                        <TextStyle6>Brand Campaigns</TextStyle6>
                    </DivStlye2>

                    <DivStlye2>
                        <img style={imgStlye2} src={bullet_iterate} alt={'brand'}></img>
                        <TextStyle6>Data Driven Iteration</TextStyle6>
                    </DivStlye2>
                </DivStlye2>

                <DivStlye2>
                    <DivStlye2>
                        <img style={imgStlye2} src={bullet_hosting} alt={'multi'}></img>
                        <TextStyle6>Experience Hosting</TextStyle6>
                    </DivStlye2>

                    <DivStlye2>
                        <img style={imgStlye2} src={bullet_multi} alt={'game'}></img>
                        <TextStyle6>Multiuser Experiences</TextStyle6>
                    </DivStlye2>

                    <DivStlye2>
                        <img style={imgStlye2} src={bullet_access} alt={'educate'}></img>
                        <TextStyle6>Accessible Experiences</TextStyle6>
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
    color : ${props=>props.color || "white"};
    font-Size: 60px;
    font-Family: "Noto Sans KR";
    font-Weight: 800;
    line-Height: 40px;
    text-Align : center;
    margin-left: ${props=>props.marginLeft || `-20%`};
`;

const TextStyle4 = styled.p`
    width: 35%;
    color : white;
    font-Size: 25px;
    font-Family: "Noto Sans KR";
    font-Weight: 400;
    line-Height: 40px;
    margin-top: -1%;
    margin-left: 10%;
`;

const TextStyle5 = styled.p`
    width: 35%;
    color : white;
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


export default Multiuser

