import React, { useState, useEffect, useCallback } from "react"
import styled from "styled-components"
import Layout from "../../components/layout"
import Banner from "../../components/banner"
import CategoryImage from "../../components/CategoryImage"
import GamesLink from "../../components/GamesLink"
import maccas_casestudy_firstframe from "../../images/maccas_casestudy_firstframe.png"
import bullet_brand from "../../images/bullet@2_brand.png"
import bullet_multi from "../../images/bullet@2_multi.png"
import bullet_access from "../../images/bullet@2_accessibility.png"
import parallax1_2 from "../../images/parallax-1-2.png"
import parallax2_1 from "../../images/parallax-2-1.png"
import usp_auth from "../../images/usp@1x_authentic.png"
import usp_convenient from "../../images/usp@1x_convenient.png"
import usp_measure from "../../images/usp@1x_measure.png"
import usp_game from "../../images/usp@2xGAME.png"
import bullet_iterate from "../../images/bullet@2_iterate.png"
import bullet_hosting from "../../images/bullet@2_hosting.png"


const BrandExperience = (props) =>{

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
                        <TextStyle1>RADICAL AUTHENTICITY</TextStyle1>                
                        <TextStyle2>We leverage a deep understanding of your brand and audience to shape uniquely engaging experiences that are totally authentic.</TextStyle2>
                    </DivStlye1>

                    <DivStlye1>
                        <img src={usp_convenient} alt ={'aggro'} style={imgStlye}></img>
                        <TextStyle1>CONVENIENCE IS KING</TextStyle1>
                        <TextStyle2>Branded experiences that live on everything, everywhere. Cost-effective impactful content that reaches your audience instantly.</TextStyle2>
                    </DivStlye1>

                    <DivStlye1>
                        <img src={usp_measure} alt ={'integ'} style={imgStlye}></img>
                        <TextStyle1>MEASURED AND AGILE</TextStyle1>
                        <TextStyle2>Goodboy technology empowers rapid expansion through live updates, evolving brand experiences as their user bases grow.</TextStyle2>
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
                    <TextStyle3>YOUR NAME IS EVERYTHING</TextStyle3>
                    <TextStyle4>Whether a fully fledged game-as-a-service, short term promotion, or multi-user experience, our purpose is to create branded destinations where audiences receive true value in return for the time they invest.</TextStyle4>
                    <TextStyle5>A Goodboy brand experience facilitates a strong emotional connection between your brand and the user. We understand the importance of hitting the right tone and crafting memorable and authentic experiences your users will want to share and return to again and again.</TextStyle5>
                    <TextStyle5>We do this by analysing your brand and specific strategic goals to determine the most effective avenue of communication to reach your audience. We discover what your audience’s needs are and create remarkable spaces in which those needs can be met. We surrender to the brand and let it guide decisions around how these spaces take shape. From the smallest of interactions through to the biggest design decisions of the core experience, we work with you to ensure every detail is infused with your brand, and authentically you.</TextStyle5>
                    <TextStyle5>Branded Experiences that Resonate.</TextStyle5>
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


export default BrandExperience

