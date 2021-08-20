import React from "react"
import mob_home1_1 from "../images/mob_home1-1.jpg"
import mob_home2_1 from "../images/mob_home2-1.jpg"


const Header = (props) => {
  const {imageUri} = props
  
  return imageUri !== null && imageUri !== undefined ? (
    <img
      style={{
        width: '100%',
        height: '100%',
        objectFit: "cover",
      }}
      src={mob_home2_1}
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
    </div>
  )
}

export default Header
