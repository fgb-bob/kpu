import React from "react"


const Header = (props) => {
    const { image } = props


  return (
    <section
      style={{
        backgroundColor: "#fff999",
        display: "flex",
        width: "100%",
        height: "900px",
        justifyContent: "center",
        alignItems: "center",
      }}
    >
      <div style={{ display: "flex", width: "60px", height: "100%" }}>left</div>

      <div
        style={{
          display: "flex",
          flex: 1,
          justifyContent: "center",
          alignItems: "center",
        }}
      >
        <div
          style={{
            display: "flex",
            flex: 1,
            height: "100%",
            justifyContent: "flex-end",
            alignItems: "center",
          }}
        >
        </div>

        <div
          style={{
            display: "flex",
            flex: 1,
            height: "100%",
            justifyContent: "flex-start",
            alignItems: "center",
          }}
        >
          <p
            style={{
              overflowX: "hidden",
              flex: 1,
              width: "0px",
              color: "#99999",
              fontSize: "20px",
              fontFamily: "NanumSquareExtraBold",
              lineHeight: "26.7px",
              letterSpacing: "-1.6px",
              whiteSpace: "nowrap",
              textOverflow: "ellipsis",
            }}
          >
              {image}
          </p>
        </div>
      </div>

      <div style={{ display: "flex", width: "60px", height: "100%" }}>right</div>
    </section>
  )
}

export default Header
