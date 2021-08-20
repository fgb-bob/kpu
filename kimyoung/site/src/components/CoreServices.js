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
import service_logo_games from "../images/service-logo@2x-games-1.png"
import service_logo_apps from "../images/service-logo@2x-apps.png"
import service_logo_brand from "../images/service-logo@2x-brand.png"
import service_logo_multiuser from "../images/service-logo@2x-multiuser.png"
import service_logo_XR from "../images/service-logo@2x-xr-1.png"
import service_logo_kids from "../images/service-logo-kids-1.png"

const CoreServices = () => {

    const Color = {
        games : '#E91E63',
        apps : '#009688',
        brand : '#673AB7',
        multi : '#9C27B0',
        XR : '#2196F3',
        kids : '#FDD835'
    }

    const style_games={
        backgroundColor : Color.games,
        width:'30%',
        height:'100%',
        justifyContent : 'center',
        alignItems : 'center',
        flexDirection : 'column'
    }

    const style_apps={
        backgroundColor : Color.apps,
        width:'30%',
        height:'20%',
        justifyContent : 'center',
        alignItems : 'center',
        flexDirection : 'column'
    }

    const style_brand={
        backgroundColor : Color.brand,
        width:'30%',
        height:'20%',
        justifyContent : 'center',
        alignItems : 'center',
        flexDirection : 'column'
    }

    const style_multi={
        backgroundColor : Color.multi,
        width:'30%',
        height:'20%',
        justifyContent : 'center',
        alignItems : 'center',
        flexDirection : 'column'
    }

    const style_XR={
        backgroundColor : Color.XR,
        width:'30%',
        height:'20%',
        justifyContent : 'center',
        alignItems : 'center',
        flexDirection : 'column'
    }

    const style_kids={
        backgroundColor : Color.kids,
        width:'30%',
        height:'20%',
        justifyContent : 'center',
        alignItems : 'center',
        flexDirection : 'column'
    }

    const style2={
        display : 'flex',
        width : `99%`,
        height : '100%',
        alignItems: "center",
        justifyContent: "space-around",
        margin : '1px'
    }

    return(
        <Layout>
            <div style={{
                display: 'flex',
                alignItems: "center",
                justifyContent : 'center'
                
            }}>
                <p style={{color: "#fff", fontSize: "100px", fontFamily: "Noto Sans KR", fontWeight: 700, lineHeight: "10px"}}>
                   Core Services
                </p>
            </div>

            <div style={style2}>

                <div style={style_games}>
                    <IconButton
                    onClick={()=>{
                            navigate("../../services/games")
                        }}>
                        <img style={{width : '80%', height : '80%'}} src={service_logo_games}></img>
                    </IconButton>
                </div>

                <div style={style_apps}>
                    <IconButton
                     onClick={()=>{
                        navigate("../../services/apps")
                    }}>
                        <img style={{width : '80%', height : '80%'}} src={service_logo_apps}></img>
                    </IconButton>
                </div>

                <div style={style_brand}>
                    <IconButton
                     onClick={()=>{
                        navigate("../../services/brand-experience")
                    }}>
                        <img style={{width : '80%', height : '80%'}} src={service_logo_brand}></img>
                    </IconButton>
                </div>
            </div>

            <div style={{height : '100px'}}></div>

            <div style={style2}>
            <div style={style_multi}>
                    <IconButton
                    onClick={()=>{
                        navigate("../../services/multiuser")
                    }}>
                        <img style={{width : '80%', height : '80%'}} src={service_logo_multiuser}></img>
                    </IconButton>
                </div>

                <div style={style_XR}>
                    <IconButton>
                        <img style={{width : '80%', height : '80%'}} src={service_logo_XR}></img>
                    </IconButton>
                </div>

                <div style={style_kids}>
                    <IconButton>
                        <img style={{width : '100%', height : '100%'}} src={service_logo_kids}></img>
                    </IconButton>
                </div>
            </div>
        </Layout>
    )
}

export default CoreServices