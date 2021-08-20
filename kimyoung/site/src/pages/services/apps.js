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


const Apps = (props) =>{

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
                        <img src={usp_easy} alt ={'ez'} style={imgStlye}></img>
                        <TextStyle1>APPS MADE EASY</TextStyle1>                
                        <TextStyle2>Package and extend the reach of your online content into App Stores. Our process also means app updates require no resubmission or time costly approvals.</TextStyle2>
                    </DivStlye1>

                    <DivStlye1>
                        <img src={usp_aggro} alt ={'aggro'} style={imgStlye}></img>
                        <TextStyle1>AGGREGATION</TextStyle1>
                        <TextStyle2>Create new platforms to extend the life of your digital portfolio. Whether games, creative or educational, we can extend the longevity of all forms of web content.</TextStyle2>
                    </DivStlye1>

                    <DivStlye1>
                        <img src={usp_integ} alt ={'integ'} style={imgStlye}></img>
                        <TextStyle1>APP EXPANSION</TextStyle1>
                        <TextStyle2>Rather than struggle to promote a new App in crowded App Stores we can inject rich, 3D, interactive content directly into your existing App via the WebView.</TextStyle2>
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
                    backgroundColor: "#CDD3DC",
                    display: "flex",
                    width: "100%",
                    height: "100%",
                    flexDirection : 'column',
                    alignItems: "center",
                    justifyContent: "center",
                }}> 
                <DivStlye3>
                    <TextStyle3>MAKING YOUR APP EFFECTIVE</TextStyle3>
                    <TextStyle4>Today, how you make your App and how you ensure its content stays fresh can be the difference between essential and deleted.</TextStyle4>
                    <TextStyle5>We extend the reach of online experiences to App Stores that are indiscernible from native code. This means we can make huge savings in resources allocated for Apps and extend the value of web content exponentially.</TextStyle5>
                    <TextStyle5>As well as packaging single experiences for App Store deployment, we also create new platforms to aggregate existing content portfolios. Products such as these can reinvigorate content languishing on declining .com URLs and give them a brand new lease of life.</TextStyle5>
                    <TextStyle5>For App owners, our technology integrates with your existing App allowing you to seamlessly introduce new experiences and messages into an already trusted and familiar App.</TextStyle5>
                    <TextStyle5>Whichever iteration of our tech is used, one thing remains constant – we give the content you own and pay for greater reach, greater impact and greater value.</TextStyle5>
                    <TextStyle5>Apps for everyone.</TextStyle5>
                </DivStlye3>

                <div style={{width : '100%',height : "100%"}}>
                    <img style={{width: '60%', height : '100%',marginLeft:'10%'}} src={serv1} alt={serv1}></img>
                    <img style={{width: '100%', height : '100%',marginTop : '-28%'}} src={serv2} alt={serv2}></img>
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
                        <img style={imgStlye2} src={bullet_html5} alt={'html5'}></img>
                        <TextStyle6>Packaged HTML5 Apps</TextStyle6>
                    </DivStlye2>

                    <DivStlye2>
                        <img style={imgStlye2} src={usp_integ} alt={'23d'}></img>
                        <TextStyle6>App Content Integration</TextStyle6>
                    </DivStlye2>

                    <DivStlye2>
                        <img style={imgStlye2} src={usp_aggro} alt={'brand'}></img>
                        <TextStyle6>Aggregation Apps</TextStyle6>
                    </DivStlye2>
                </DivStlye2>

                <DivStlye2>
                    <DivStlye2>
                        <img style={imgStlye2} src={bullet_educate} alt={'multi'}></img>
                        <TextStyle6>Education Apps</TextStyle6>
                    </DivStlye2>

                    <DivStlye2>
                        <img style={imgStlye2} src={bullet_access} alt={'game'}></img>
                        <TextStyle6>Accessible Apps</TextStyle6>
                    </DivStlye2>

                    <DivStlye2>
                        <img style={imgStlye2} src={bullet_xr} alt={'educate'}></img>
                        <TextStyle6>XR Apps</TextStyle6>
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
    color : ${props=>props.color || "black"};
    font-Size: 60px;
    font-Family: "Noto Sans KR";
    font-Weight: 800;
    line-Height: 40px;
    text-Align : center;
    margin-left: ${props=>props.marginLeft || `-20%`};
`;

const TextStyle4 = styled.p`
    width: 35%;
    color : black;
    font-Size: 25px;
    font-Family: "Noto Sans KR";
    font-Weight: 400;
    line-Height: 40px;
    margin-top: -1%;
    margin-left: 10%;
`;

const TextStyle5 = styled.p`
    width: 35%;
    color : black;
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


export default Apps

