import React, { useState, useEffect, useCallback } from "react"
import Layout from "./layout"
import Header from "./header"
import { navigate } from "gatsby"
import icon_left_arrow from "../images/icon_left_arrow.png"
import icon_right_arrow from "../images/icon_right_arrow.png"
import { IconButton } from "@material-ui/core"
import Banner from "./banner"
import contact_map from "../images/contact_map.jpg"
import CategoryImage from "./CategoryImage"

import maccas_casestudy_firstframe from "../images/maccas_casestudy_firstframe.png"
import sw from "../images/sw-video-1440x810.jpg"
import Sonic from "../images/sonic-1440x810.jpg"
import tooncup from "../images/CaseStudy-ToonCup-FirstFramed-1440x810.jpg"
import service_logo_games from "../images/service-logo@2x-games-1.png"
import service_logo_apps from "../images/service-logo@2x-apps.png"
import service_logo_brand from "../images/service-logo@2x-brand.png"
import service_logo_multiuser from "../images/service-logo@2x-multiuser.png"
import service_logo_XR from "../images/service-logo@2x-xr-1.png"
import service_logo_kids from "../images/service-logo-kids-1.png"
import styled from "styled-components"

const GamesLink = () =>{
    const sonic= {
        title : 'SEGA / FACBOOK',
        text : 'Sonic Jump for Facebook Instant Games'
    }
    const imgStlye={
        width: '100%',
        height: '100%'
    }

    return(
        <section style={{
            display: "flex",
            width: "100%",
            height: "100%",
            flexDirection : 'column',
            alignItems: "center",
            justifyContent: "center"
        }}>
            <DivStyle1>
                <DivStyle2>
                    <img style={imgStlye} src={maccas_casestudy_firstframe} alt={'mac'}></img>
                    <TextStyle1>TMS / MCDONALD'S</TextStyle1>
                    <TextStyle2>McDonald's in-App Games</TextStyle2>
                </DivStyle2>
            

                <DivStyle2>
                    <img style={imgStlye} src={sw} alt={'sonic'}></img>
                    <TextStyle1>DISNEY</TextStyle1>
                    <TextStyle2>Star Wars Arcade</TextStyle2>
                </DivStyle2>
            </DivStyle1>

            <DivStyle1>
                <DivStyle2>
                    <img style={imgStlye} src={Sonic} alt={'sonic'}></img>
                    <TextStyle1>SEGA / FACEBOOK</TextStyle1>
                    <TextStyle2>Sonic Jump for Facebook Instant Games</TextStyle2>
                </DivStyle2>
            

                <DivStyle2>
                    <img style={imgStlye} src={tooncup} alt={'tooncup'}></img>
                    <TextStyle1>CARTOON NETWORK</TextStyle1>
                    <TextStyle2>Toon Cup 2020</TextStyle2>
                </DivStyle2>
            </DivStyle1>
        </section>
    )
}

export default GamesLink

const DivStyle1 = styled.div`
    width : 100%;
    height: 100%;
    display: flex;
    flex-direction: row;
    align-items: center;
    justify-content: center;
`

const DivStyle2 = styled.div`
    width : 100%;
    height: 50%;
    background-color: #353F50;
    display: flex;
    flex-direction: column;
    align-items: left;
    justify-content: left;
    margin : 1%
`

const TextStyle1 = styled.p`
    color : #fff;
    font-Size: 15px;
    font-Family: "Noto Sans KR";
    font-Weight: 400;
    line-Height: 40px;
    margin-left: 3%;
`

const TextStyle2 = styled.p`
    color : #fff;
    font-Size: 35px;
    font-Family: "Noto Sans KR";
    font-Weight: 600;
    line-Height: 40px;
    margin-left: 3%;
    margin-top:-3%;
`