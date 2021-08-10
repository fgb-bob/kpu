import React, { useState, useEffect, useCallback } from "react"
import Layout from "./layout"
import Header from "./header"
import client_facebook from "../images/client/client_facebook.png"

const Banner = () => {
    return (
        <div style={{position : 'relative', width : "100%", height : "100%", display : 'flex',alignItems : 'center', justifyContent : 'center'}}>
            <img style={{width : "10%", height : "30%"}} src={client_facebook} alt={"facebook"}></img>
            <img style={{width : "10%", height : "30%", marginLeft : '2%'}} src={client_facebook} alt={"facebook"}></img>
            <img style={{width : "10%", height : "30%", marginLeft : '2%'}} src={client_facebook} alt={"facebook"}></img>
            <img style={{width : "10%", height : "30%", marginLeft : '2%'}} src={client_facebook} alt={"facebook"}></img>
            <img style={{width : "10%", height : "30%", marginLeft : '2%'}} src={client_facebook} alt={"facebook"}></img>
        </div>
    )
}

export default Banner