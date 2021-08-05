import React, { useEffect, useState } from "react"
import { navigate } from "gatsby"

const Menu = (props) => {

    return(
        <section>
            style={{
                marginTop: "0px",
                backgroundColor: "#fff",
                display: "flex",
                width: "100%",
                height: "66.7px",
                justifyContent: "space-around",
                alignItems: "left",
                boxShadow: "0 -3.3px 6.7px 0px #0d212223",
      }}
      <button
        style={{
          zIndex: "100",
          backgroundColor: "inherit",
          display: "flex",
          flexDirection: "column",
          width: "fit-content",
          height: "fit-content",
          justifyContent: "center",
          alignItems: "center",
        }}
        onClick={() => {
          navigate("/app/main")
          setFocusingTab("홈")
        }}
      ></button>
        <img style={{ width: "33.3px", height: "33.3px", margintop: "8.3px" }} src={focusingTab === "홈" ? homeOn : home} alt={"홈on"} />
        </section>
    )
}