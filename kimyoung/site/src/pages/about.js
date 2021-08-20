import React, { useState, useEffect, useCallback } from "react"
import styled from "styled-components"
import Layout from "../components/layout"
import Header from "../components/header"
import { navigate } from "gatsby"
import { IconButton } from "@material-ui/core"
import Banner from "../components/banner"
import contact_map from "../images/contact_map.jpg"
import CategoryImage from "../components/CategoryImage"
import CoreServices from "../components/CoreServices"
import maccas_casestudy_firstframe from "../images/maccas_casestudy_firstframe.png"
import Paddington from "../images/Paddington_Casestudy_Firstframe1.jpg"
import logo_html5 from "../images/about/logo-html5-2.png"
import logo_webgl from "../images/about/logo-webgl.png"
import logo_pixijs_v5 from "../images/about/pixijs_v5.png"
import logo_unity from "../images/about/unity.png"

const About = (props) =>{

    const [num, setNum] = useState(0)

    const tinystlye={
        color: "#161C24",
        fontSize: "18px",
        fontFamily: "Noto Sans KR",
        fontWeight: 400,
        lineHeight: "30px",
        marginLeft : '35%'
    }

    const fontstlye2={
        color: "#fff",
        fontSize: "18px",
        fontFamily: "Noto Sans KR",
        fontWeight: 400,
        lineHeight: "30px",
        marginLeft : '35%'
    }

    const fontstlye3={
        color: "black",
        fontSize: "25px",
        fontFamily: "Noto Sans KR",
        fontWeight: 500,
        lineHeight: "0px",
    }

    const fontstlye4={
        color: "black",
        fontSize: "15px",
        fontFamily: "Noto Sans KR",
        lineHeight: "20px",
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
                backgroundColor: "#CDD3DC",
                display: "flex",
                width: "100%",
                height: "100%",
                flexDirection : 'column',
                alignItems: "center",
                justifyContent: "center",
            }}>
            <div style={{height : '100px'}}></div>
            <div style={{display : 'flex' , height : '50%', width : `45%`}}>
                <p style={{ color: "#161C24", fontSize: "52px", fontFamily: "Noto Sans KR", fontWeight: 700, lineHeight: "10px", letterSpacing: "-1.08px"}}>
                    WE DO THIS BY
                </p>
            </div>
            <div stlye={{display : 'flex' , height : '10%', width : `100%`}}>
                <p style={{display : 'flex' , height : '100%', width : `50%`, marginLeft : '35%', color: "#161C24", fontSize: "27px", fontFamily: "Noto Sans KR", fontWeight: 400, lineHeight: "40px", whiteSpace : "wordbreak"}}>
                    Analysing your brand and goals to determine the most effective
                    avenue of communication to reach your audience.
                </p>
            </div>
            <div style={{height : '100%', width : `65%`,flexDirection : 'row', marginRight : '3%'}}>
                <p style={tinystlye}>
                    Content that surprises and delights no matter where the audience is or how we reach them.
                
                </p>

                <p style={tinystlye}>
                    It is the essence of our company, an egalitarian approach to creation where your brand is king and the experience must support it whether on a diminutive mobile device or as an all encompassing virtual world.
                </p> 

                <p style={tinystlye}>
                    In the digital space where every passing day ushers in new techniques and trends, a less is more approach can often be a tough discipline to maintain. For us every interaction, every touch, every gesture is built with passion and purpose. If it doesn't add, we subtract.
                </p> 

                <p style={tinystlye}>
                    This focus and singularity is the reason why what we produce is so hard to put down.
                </p> 
                
                   
            </div>
            <div style={{height : '100px', width : '20%'}}></div>    
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
            <div style={{height : '50px'}}></div>
            <div style={{display : 'flex' , height : '50%', width : `45%`}}>
                <p style={{ color: "#fff", fontSize: "55px", fontFamily: "Noto Sans KR", fontWeight: 700, lineHeight: "10px", letterSpacing: "-1.08px"}}>
                    LIVING IN YOUR BRAND
                </p>
            </div>
            <div style={{height : '100%', width : `65%`,flexDirection : 'row', marginRight : '3%'}}>
                <p style={fontstlye2}>
                    Whether a fully fledged game or the opportunity to share stories with fellow viewers, our purpose is to create destinations where people feel that the time they spend is for their own reward.
                </p>

                <p style={fontstlye2}>
                    The modern audience is far too smart for one-way marketing noise. They shape their own digital landscapes and demand experiences that align with their requirements. Our aim is to work with you to discover what their needs are and create spaces in which those needs can be met.
                </p> 
            </div>
            <div style={{height : '50px'}}></div>

            <div style={{display : 'flex', height : '100%', width : '100%', flexDirection : 'row', justifyContent : 'center'}}>
                <img src={Paddington} alt ={'paddington'} style={{width : '30%', height : '50%'}}></img>
                <img src={Paddington} alt ={'paddington'} style={{width : '40%', height : '50%',marginLeft : '5%',marginTop:'10%'}}></img>                
            </div>
            <div style={{height : '50px', width : '20%'}}></div>    
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
                backgroundColor: "#ECEDF1",
                display: "flex",
                width: "100%",
                height: "100%",
                flexDirection : 'column',
                alignItems: "center",
                justifyContent: "center",
            }}>
            <div style={{height : '50px'}}></div>
            <div style={{display : 'flex', flexDirection : 'row'}}>
                
                <div style={{width : '60%', height : '100%', display : 'flex', justifyContent : 'center', flexDirection : 'column', marginLeft : '10%'}}>
                    <p style={{color : "#3E4078", fontSize : "15px",fontWeight: 400}}>_RIGHT NOW</p>
                    <img src={logo_html5} alt ={'html5'} style={{width : '20%', height : '20%',marginTop : '3%'}}></img>
                    <img src={logo_webgl} alt ={'webgl'} style={{width : '25%', height : '20%',marginTop : '3%'}}></img>
                    <img src={logo_pixijs_v5} alt ={'pixi'} style={{width : '25%', height : '20%',marginTop : '3%'}}></img>
                    <img src={logo_unity} alt ={'unity'} style={{width : '25%', height : '20%',marginTop : '3%'}}></img>
                </div>
                <div style={{width : '100%', height : '100%', display : 'flex', justifyContent : 'center', flexDirection : 'column', marginRight : '20%'}}>
                    <p style={{ color: "black", fontSize: "55px", fontFamily: "Noto Sans KR", fontWeight: 700, lineHeight: "0px", letterSpacing: "-1.08px"}}>
                        WE LOVE TECHNOLOGY
                    </p>

                    <p style={fontstlye3}>
                        So much so, we created our own.
                    </p>

                    <p style={fontstlye4}>
                        PixiJS is the platform upon which we and now many others build content. It was created to fill the gap left in a 'post Flash era' following the advent of the mobile internet. The appetite for incredible, engaging experiences didn't vanish with the dawn of the smartphone and tablet, but the technology to supply it did.
                    </p>

                    <p style={fontstlye4}>
                        In light of this we created PixiJS to empower ourselves and others to produce interactive content that reaches everyone, everywhere. Four years after Pixi's inception, this concept seems inevitable and obvious but we are incredibly proud to have founded and grown a technology platform that enables not only ourselves, but thousands of other creators to make products that have shaped how the modern internet can be experienced.
                    </p>

                    <p style={fontstlye3}>
                        Seismic shifts take groundbreaking solutions.
                    </p>

                    <p style={fontstlye4}>
                        The reason we created PixiJS was because we saw a sea change in how people were going to experience the web. And just as it happened before, we are always looking for how it will change next. VR, IoT, Post-browser... All probably old hat by the time this is written down. The specifics of technological change are not important. Goodboy was built upon change and embraces its every iteration. The constant is this – audiences want inspiration and delight. We can give it to them using whatever technology is required.   
                    </p>
                </div>
            </div>
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
            <p style={{color : "#fff", fontSize : "15px"}}>_OUR RECOGNITION</p>
            <Banner></Banner>
            <div style={{height : '50px'}}></div>
        </section>

        </Layout>
    )
}

const Container = styled.div`
    width : 100%;
    height: 100%;
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
`;



export default About