import "./BestPlayersWindow.css"
import {Button} from "../UI/Button/Button.jsx";
import ICONS from "../../assets/icons.jsx";
import {useEffect, useState} from "react";
import ReactDom from "react-dom";
import {Banner} from "../UI/Banner/Banner.jsx";
import {axiosToRatingService} from "../../hooks/useAxios.js";
import {toast} from "react-toastify";

const MODAL_STYLE = {
    position: "fixed",
    top: "25%",
    left: "50%",
    width: "50%",
    transform: "translate(-50%, -50%)",
    backgroundColor: 'white',
    padding: '50px',
    zIndex: 1000
}
const OVERLAY_STYLE = {
    position: 'fixed',
    top: 0,
    left: 0,
    right: 0,
    bottom: 0,
    backgroundColor: 'rgba(0,0,0, .7)',
    zIndex: 1000
}
export function BestPlayersWindow({isOpen, onClose, ...rest}) {
    const [leaders, setLeaders] = useState([
        {username: "100", rating:1},
        {username: "123", rating:1},
        {username: "123", rating:1},
        {username: "22", rating:1},
        {username: "232", rating:1},
        {username: "2323", rating:1},
        {username: "2232", rating:1}
    ]);
    const fetchData = async () => {
        try {
            const response = await axiosToRatingService.get(`/users?offset=0&count=10`);
            setLeaders([...response.data.map(l => ({ username: l.userName, rating: l.rating} ))]);
        } catch (error) {
            toast.error(`Leaderboard: ${error}`, { toastId: "LeaderboardError" })
        }
    }
    useEffect(() => {
        fetchData();
    }, []);

    if (!isOpen) return null
    return ReactDom.createPortal(
        <>
            <div style={OVERLAY_STYLE}/>
            <Banner className={"bestPlayersWindow"} style={MODAL_STYLE} shadow={true} {...rest} >
                <Button iconPath={ICONS.cross} onClick={onClose} style={{marginBottom: "10px"}}></Button>
                <div style={{display: "flex", width:"100%", textAlign: "center"}}>
                    <p1 style={{fontWeight: "bold", }}>Leaderboard</p1>
                </div>

                <div style={{display: "flex", justifyContent: "space-between"}}>
                <span>Username</span>
                        <span>Rating</span>
                </div>
                {leaders.map((l,index) =>
                    <div key={index} style={{display: "flex", justifyContent: "space-between"}}>
                        <span>
                            <span style={{fontWeight:"bold"}}>{index+1} </span>
                            {l.username}
                        </span>
                        <span>{l.rating}</span>
                    </div>)}
            </Banner>
        </>,
        document.getElementById('portal')
    )
}