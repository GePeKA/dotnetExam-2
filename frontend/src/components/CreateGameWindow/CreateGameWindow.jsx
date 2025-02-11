import "./CreateGameWindow.css"
import {Button} from "../UI/Button/Button.jsx";
import ICONS from "../../assets/icons.jsx";
import {Banner} from "../UI/Banner/Banner.jsx";
import ReactDom from "react-dom"
import {Input} from "../UI/Input/Input.jsx";

const MODAL_STYLE = {
    position: "fixed",
    top: "35%",
    left: "50%",
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


export function CreateGameWindow({isOpen, onClose, ...rest}) {
    if (!isOpen) return null
    return ReactDom.createPortal(
        <>
            <div style={OVERLAY_STYLE}/>
            <Banner className={"create-game-window"} style={MODAL_STYLE} shadow={true} {...rest} >
                <Button className={"close-window-button"} iconPath={ICONS.cross} onClick={onClose}/>
                <label htmlFor={"rating"} >Enter max rating: </label>
                <Input type={"text"} id="rating" placeholder="max rating"></Input>
                <Button text={"Create game"} className={"create-game-button"}/>
            </Banner>
        </>,
        document.getElementById('portal')
    )
}