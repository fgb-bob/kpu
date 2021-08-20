import React, { useState, useEffect, useCallback } from "react"
import Layout from "./layout"
import Header from "./header"
import client_adobe from "../images/client/client_adobe.png"
import client_comic_relief from "../images/client/client_comic_relief.png"
import client_facebook from "../images/client/client_facebook.png"
import client_grubhub from "../images/client/client_grubhub.png"
import client_itv_sport from "../images/client/client_itv_sport-1.png"

const Banner = () => {
    
    return (
        <div style={{position : 'relative', width : "100%", height : "100%", display : 'flex',alignItems : 'center', justifyContent : 'center'}}>
            <img style={{width : "10%", height : "30%"}} src={client_adobe} alt={"adobe"}></img>
            <img style={{width : "10%", height : "30%", marginLeft : '2%'}} src={client_comic_relief} alt={"comic"}></img>
            <img style={{width : "10%", height : "30%", marginLeft : '2%'}} src={client_grubhub} alt={"facebook"}></img>
            <img style={{width : "10%", height : "30%", marginLeft : '2%'}} src={client_itv_sport} alt={"facebook"}></img>
            <img style={{width : "10%", height : "30%", marginLeft : '2%'}} src={client_facebook} alt={"facebook"}></img>
        </div>
    )
}

export default Banner