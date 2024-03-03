function App() {
	const feedbackInput = React.useRef({
		'id': '', 
		'rating': 5 
	});
	const [statusMessage, setStatusMessage] = React.useState('');
	const putFeedback = async () => {
		var request = {
			method: 'put',
			headers: {'Content-Type': 'application/json'},
			body: JSON.stringify(feedbackInput.current)
		};
		var response = await fetch('http://localhost:5000/api/review', request);
		if(response.ok){
			setStatusMessage('Feedback accepted');
		}else{
			setStatusMessage('Feedback rejected');
		}
	};
	return (
		<div>
			<h1>Welcome Visitor</h1>
			<hr/>
			<h3>All Feedbacks</h3>
			<FeedbacksView/>
			<hr/>
			<h3>Submit Feedback</h3>
			<div className='form-entry'>
				<div><b>Your Name</b></div>
				<div>
					<input onChange={e => feedbackInput.current.id = e.target.value}/>
				</div>
			</div>
			<div className='form-entry'>
				<div><b>Your Rating</b></div>
				<div>
					<select onChange={e => feedbackInput.current.rating = e.target.value}>
						<option value="5">Excellent</option>
						<option value="4">Good</option>
						<option value="3">Average</option>
						<option value="2">Poor</option>
						<option value="1">Pathetic</option>
					</select>
				</div>
			</div>
			<button onClick={putFeedback}>Submit</button>
			<p>
				<i>{statusMessage}</i>
			</p>
			<hr/>
		</div>
	)
}

function FeedbacksView() {
	const [allFeedbacks, setAllFeedbacks] = React.useState([]);
	React.useEffect(() => {
		loadFeedbacks();
	});
	async function loadFeedbacks() {
		var response = await fetch('http://localhost:5000/api/review?min=1');
		if(response.ok) {
			setAllFeedbacks(await response.json());
		}else{
			setAllFeedbacks([]);
		}		
	}
	return (
		<div>
		{allFeedbacks.length > 0 ? (
			<table width="30%">
				{allFeedbacks.map((entry, index) => (
					<tbody key={index}>
						<tr>
							<td>{entry.id}</td>
							<td align="right">{"*".repeat(entry.rating)}</td>
						</tr>
					</tbody>
				))}
			</table>
		) : null}
		</div>
	)
}

ReactDOM.createRoot(document.getElementById('root')).render(
	<React.StrictMode>
		<App/>
	</React.StrictMode>
);
