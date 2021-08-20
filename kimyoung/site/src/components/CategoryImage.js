import React from "react"
import maccas_casestudy_firstframe from "../images/maccas_casestudy_firstframe.png"
import sw from "../images/sw-video-1440x810.jpg"
import sonic from "../images/sonic-1440x810.jpg"
import tooncup from "../images/CaseStudy-ToonCup-FirstFramed-1440x810.jpg"


const CategoryImage = (props) => {
  const { imageUri, title } = props
  

  return imageUri !== null && imageUri !== undefined ? (
    
    <img
        style={{
          width: '100%',
          height: '100%',
        }}
        src={imageUri}
        alt={imageUri}
      />
    
  ) : (
    <div
      style={{
        backgroundColor: "##252C39",
        display: "flex",
        justifyContent: "center",
        alignItems: "center",
        width: '100%',
        height: '100%',
      }}
    >
      <p
        style={{
          color: "#212223",
          fontSize: '10px',
          fontFamily: "NanumSquareExtraBold",
          lineHeight: "20px",
          letterSpacing: "-0.84px",
        }}
      >
        {title}
      </p>
    </div>
  )
}

export default CategoryImage
